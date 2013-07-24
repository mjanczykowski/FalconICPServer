using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using F4KeyFile;
using KeyboardInput;
using NLog;

namespace FalconICPServer
{
    public static class KeyfileUtils
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Returns key combo description.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GetKeyDescription(KeyBinding keys)
        {
            if (keys == null) throw new ArgumentNullException();

            StringBuilder str = new StringBuilder();

            if (keys.Key.ScanCode <= 0) //no primary key set
            {
                return null;
            }

            if (keys.ComboKey.ScanCode > 0)
            {
                if (keys.ComboKey.Modifiers != KeyModifiers.None)
                {
                    str.AppendFormat("{0} + {1}, ", keys.ComboKey.Modifiers.ToString(), ((ScanCodes)keys.ComboKey.ScanCode).ToString());
                }
                else
                {
                    str.AppendFormat("{0}, ", ((ScanCodes)keys.ComboKey.ScanCode).ToString());
                }
            }

            if (keys.Key.Modifiers != KeyModifiers.None)
            {
                str.AppendFormat("{0} + {1}", keys.Key.Modifiers.ToString(), ((ScanCodes)keys.Key.ScanCode).ToString());
            }
            else
            {
                str.Append(((ScanCodes)keys.Key.ScanCode).ToString());
            }
            return str.ToString();
        }

        /// <summary>
        /// Sends keystroke scancodes to input.
        /// </summary>
        /// <param name="keys">KeyBinding for given callback</param>
        public static void SendKeystroke(KeyBinding keys)
        {
            if (keys == null) throw new ArgumentNullException();

            if (keys.Key.ScanCode <= 0) //no primary key set
            {
                return;
            }
            if (keys.ComboKey.ScanCode > 0)
            {
                SendKeysWithModifiers(keys.ComboKey);
            }
            SendKeysWithModifiers(keys.Key);
        }

        /// <summary>
        /// Simulates key presses using <see cref="SendKeyInput"/>SendKeyInput class.
        /// </summary>
        /// <param name="keys">Key with modifiers to simulate</param>
        public static void SendKeysWithModifiers(KeyWithModifiers keys)
        {
            int mods = (int)keys.Modifiers;
            bool shift = ((mods & 1) == 1);
            bool ctrl = ((mods & 2) == 2);
            bool alt = ((mods & 4) == 4);

            if (shift) SendKeyInput.KeyDown(ScanCode.LeftShift);
            if (ctrl) SendKeyInput.KeyDown(ScanCode.LeftControl);
            if (alt) SendKeyInput.KeyDown(ScanCode.LeftAlt);

            SendKeyInput.KeyPress((ScanCode)keys.ScanCode);

            if (alt) SendKeyInput.KeyUp(ScanCode.LeftAlt);
            if (ctrl) SendKeyInput.KeyUp(ScanCode.LeftControl);
            if (shift) SendKeyInput.KeyUp(ScanCode.LeftShift);
        }

        /*
        public static uint[] ConvertBindingToScanCodes(KeyBinding keys)
        {
            int length = 0;
            if(keys.ComboKey.ScanCode != -1)
            {
                length = modifiersCount[(int)keys.ComboKey.Modifiers] + 1;
            }
            if (keys.Key.ScanCode != -1)
            {
                length += modifiersCount[(int)keys.Key.Modifiers] + 1;
            }
            else
            {
                //if no primary key set
                return null;
            }
            uint[] scanCodes = new uint[length];
            int keyInd = 0;

            if(keys.ComboKey.ScanCode != -1)
            {
                byte mask = 1;  //binary mask
                for (int i = 0; i < 3; i++)
                {
                    if(((int)keys.ComboKey.Modifiers & mask) == 1)
                }
            }
        }*/

        private static int[] modifiersCount = { 0, 1, 1, 2, 1, 2, 2, 3 };
    }
}
