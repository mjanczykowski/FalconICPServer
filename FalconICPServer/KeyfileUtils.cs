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
                str.AppendFormat("{0}{1}, ", keyModifiersDesc[(int)keys.ComboKey.Modifiers], GetScanCodeDescription((ScanCodes)keys.ComboKey.ScanCode));
            }
            str.AppendFormat("{0}{1}", keyModifiersDesc[(int)keys.Key.Modifiers], GetScanCodeDescription((ScanCodes)keys.Key.ScanCode));

            return str.ToString();
        }

        /// <summary>
        /// Return key description for temporary combo
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GetTempKeyDescription(KeyBinding keys)
        {
            if (keys == null) throw new ArgumentNullException();

            return string.Format("{0}{1}", keyModifiersDesc[(int)keys.Key.Modifiers], GetScanCodeDescription((ScanCodes)keys.Key.ScanCode));
        }

        public static string GetScanCodeDescription(ScanCodes sc)
        {
            switch (sc)
            {
                case ScanCodes.One:
                    return "1";
                case ScanCodes.Two:
                    return "2";
                case ScanCodes.Three:
                    return "3";
                case ScanCodes.Four:
                    return "4";
                case ScanCodes.Five:
                    return "5";
                case ScanCodes.Six:
                    return "6";
                case ScanCodes.Seven:
                    return "7";
                case ScanCodes.Eight:
                    return "8";
                case ScanCodes.Nine:
                    return "9";
                case ScanCodes.Zero:
                    return "0";
                case ScanCodes.Minus:
                    return "-";
                case ScanCodes.Equals:
                    return "=";
                case ScanCodes.LBracket:
                    return "[";
                case ScanCodes.RBracket:
                    return "]";
                case ScanCodes.Return:
                    return "Enter";
                case ScanCodes.Semicolon:
                    return ";";
                case ScanCodes.Apostrophe:
                    return "'";
                case ScanCodes.Grave:
                    return "~";
                case ScanCodes.Backslash:
                    return "\\";
                case ScanCodes.Comma:
                    return ",";
                case ScanCodes.Period:
                    return ".";
                case ScanCodes.Slash:
                    return "/";
                case ScanCodes.Multiply:
                    return "NumPad *";
                case ScanCodes.Subtract:
                    return "NumPad -";
                case ScanCodes.Add:
                    return "NumPad +";
                case ScanCodes.Decimal:
                    return "NumPad .";
                case ScanCodes.NumPadEnter:
                    return "NumPad Enter";
                case ScanCodes.Divide:
                    return "NumPad /";
                case ScanCodes.Prior:
                    return "Page Up";
                case ScanCodes.Next:
                    return "Page Down";
                default:
                    return sc.ToString();
            }
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

        private static int[] modifiersCount = { 0, 1, 1, 2, 1, 2, 2, 3 };

        private static string[] keyModifiersDesc = {
                                        "",
                                        "Shift + ",
                                        "Ctrl + ",
                                        "Ctrl + Shift + ",
                                        "Alt + ",
                                        "Shift + Alt + ",
                                        "Ctrl + Alt + ",
                                        "Ctrl + Shift + Alt + "
                                    };
    }
}
