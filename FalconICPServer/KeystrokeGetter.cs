﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using F4KeyFile;
using FalconICPServer.Properties;
using NLog;
using KeyboardInput;
using Microsoft.DirectX.DirectInput;

namespace FalconICPServer
{
    public partial class KeystrokeGetter : Form
    {
        private const int DEFAULT_SOUND_ID = 122;

        private static Dictionary<string, int> CALLBACK_SOUND_IDS = new Dictionary<string, int>()
        {
            {"SimICPCom1", 122},
            {"SimICPCom2", 122},
            {"SimICPIFF", 122},
            {"SimICPLIST", 122},
            {"SimICPAA", 122},
            {"SimICPAG", 122},
            {"SimICPDEDDOWN", 120},
            {"SimICPDEDUP", 120},
            {"SimICPDEDSEQ", 120},
            {"SimICPResetDED", 120},
            {"SimICPCLEAR", 122},
            {"SimICPTILS", 122},
            {"SimICPALOW", 122},
            {"SimICPTHREE", 122},
            {"SimICPStpt", 122},
            {"SimICPCrus", 122},
            {"SimICPSIX", 122},
            {"SimICPMark", 122},
            {"SimICPEIGHT", 122},
            {"SimICPNINE", 122},
            {"SimICPZERO", 122},
            {"SimICPEnter", 122},
            {"SimICPNext", 126},
            {"SimICPPrevious", 126},
            {"SimDriftCOOn", 121},
            {"SimDriftCOOff", 121},
            {"SimWarnReset", 115},
            {"SimSetWX", 122},
            {"SimFlirLevelUp", 122},
            {"SimFlirLevelDown", 122}
        };

        private string callback;
        private KeyFile keyFile;
        public KeyBinding newBinding { get; private set; }
        
        private Microsoft.DirectX.DirectInput.Device keyboard;

        private KeystrokeGetter(KeyFile keyFile, string callback)
        {
            this.keyFile = keyFile;
            this.callback = callback;
            InitializeComponent();
            labelMessage.Text = String.Format(Resources.info_press_keys_for_callback, callback);
            var b = keyFile.GetBindingForCallback(callback);
            if (b is KeyBinding)
            {
                var kb = (b as KeyBinding);
                newBinding = new KeyBinding(callback, kb.SoundId, new KeyWithModifiers(kb.Key.ScanCode, kb.Key.Modifiers), new KeyWithModifiers(kb.ComboKey.ScanCode, kb.ComboKey.Modifiers), kb.UIVisibility, kb.Description);
                lblKeystroke.Text = KeyfileUtils.GetKeyDescription(newBinding);
            }
            else
            {
                int soundId;
                soundId = CALLBACK_SOUND_IDS.TryGetValue(callback, out soundId) ? soundId : DEFAULT_SOUND_ID;
                newBinding = new KeyBinding(callback, soundId, new KeyWithModifiers(0, 0), new KeyWithModifiers(0, 0), UIVisibility.VisibleWithChangesAllowed, callback);
            }
            this.DIInitializeKeyboard();
        }

        /// <summary>
        /// Reads modifier keys status from DirectInput keyboard device.
        /// </summary>
        /// <returns>Modifiers value (as in KeyModifiers enum)</returns>
        private KeyModifiers DIReadModifiers()
        {
            KeyboardState keys = keyboard.GetCurrentKeyboardState();
            int modifiers = 0;
            if (keys[Key.LeftShift] || keys[Key.RightShift]) modifiers ++;
            if (keys[Key.LeftControl] || keys[Key.RightControl]) modifiers += 2;
            if (keys[Key.LeftAlt] || keys[Key.RightAlt]) modifiers += 4;

            return (KeyModifiers)modifiers;
        }

        /// <summary>
        /// Initializes DirectInput keyboard device.
        /// </summary>
        private void DIInitializeKeyboard()
        {
            keyboard = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
            keyboard.SetCooperativeLevel(this, CooperativeLevelFlags.Background | 
                CooperativeLevelFlags.NonExclusive);
            keyboard.Acquire();
        }

        /// <summary>
        /// Shows the KeystrokeGetter dialog. Returns dialog's result. 
        /// </summary>
        /// <param name="keyFile">Current keyFile</param>
        /// <param name="callback">Callback to edit</param>
        /// <returns>Result of the dialog</returns>
        public static KeyBinding Show(KeyFile keyFile, string callback)
        {
            var dialog = new KeystrokeGetter(keyFile, callback);

            var msgFilter = new KeyGetterMessageFilter(dialog);
            Application.AddMessageFilter(msgFilter);

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                dialog.newBinding = null;
            }

            Application.RemoveMessageFilter(msgFilter);
            dialog.keyboard.Unacquire();
            return dialog.newBinding;
        }

        /// <summary>
        /// Checks if keystroke is not already used by another callback
        /// and sets controls state according to validation result.
        /// </summary>
        private void ValidateKeystroke()
        {
            bool valid = true;
            foreach (var binding in keyFile.Lines)
            {
                if (!(binding is KeyBinding))
                {
                    continue;
                }

                var keyBinding = binding as KeyBinding;

                if (!keyBinding.Callback.Equals(newBinding.Callback) && sameKeysAssigned(newBinding, keyBinding))
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                lblKeystroke.BackColor = Color.LightGreen;
                btnOK.Enabled = true;
            }
            else
            {
                lblKeystroke.BackColor = Color.LightCoral;
                btnOK.Enabled = false;
            }
        }

        private bool sameKeysAssigned(KeyBinding a, KeyBinding b)
        {
            return a.Key.ScanCode.Equals(b.Key.ScanCode) && a.Key.Modifiers.Equals(b.Key.Modifiers)
                && a.ComboKey.ScanCode.Equals(b.ComboKey.ScanCode) && a.ComboKey.Modifiers.Equals(b.ComboKey.Modifiers);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    
        private class KeyGetterMessageFilter : IMessageFilter
        {
            private KeystrokeGetter ownerForm;

            public const int WM_KEYDOWN = 0x0100;
            public const int WM_KEYUP = 0x0101;
            public const int WM_SYSKEYDOWN = 0x104;
            public const int WM_SYSKEYUP = 0x105;

            public KeyGetterMessageFilter(KeystrokeGetter owner)
            {
                ownerForm = owner;
            }

            public bool PreFilterMessage(ref Message m)
            {
                // Check KEY DOWN
                if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN )
                {
                    // Checking modifier keys state
                    var vk = (VirtualKeyCode)m.WParam;

                    var modifiers = ownerForm.DIReadModifiers();

                    if (vk != VirtualKeyCode.CONTROL && vk != VirtualKeyCode.SHIFT && vk != VirtualKeyCode.MENU
                        && vk != VirtualKeyCode.NUMLOCK && vk != VirtualKeyCode.PAUSE )
                    {
                        var mScanCode = GetScanCodeFromMsg(m);

                        ownerForm.newBinding.Key.Modifiers = modifiers;
                        ownerForm.newBinding.Key.ScanCode = mScanCode;

                        ownerForm.lblKeystroke.Text = KeyfileUtils.GetTempKeyDescription(ownerForm.newBinding);

                        ownerForm.ValidateKeystroke();
                    }
                    return true; // Event handled
                }
                return false;
            }

            /// <summary>
            /// Extracts scancode compatible with DirectInput key codes from Message.
            /// </summary>
            /// <param name="m">Message to parse</param>
            /// <returns>Scancode of the key described in the Message</returns>
            private int GetScanCodeFromMsg(Message m)
            {
                VirtualKeyCode vk = (VirtualKeyCode)m.WParam;

                var mScanCode = -1;
                // PAUSE and NUMLOCK keys often have exchanged scancodes
                if (vk == VirtualKeyCode.PAUSE)
                {
                    mScanCode = 197;
                }
                else if (vk == VirtualKeyCode.NUMLOCK)
                {
                    mScanCode = 69;
                }
                else
                {
                    // Read scan code from LParam (bits 16-23) and check bit 24 containing information
                    // if key is extended. If positive add 128 to scan code.
                    mScanCode = (m.LParam.ToInt32() >> 16) & 0xff;
                    int x = (m.LParam.ToInt32() >> 17) & 128;
                    mScanCode += x;
                }

                return mScanCode;
            }
        }
    }
}
