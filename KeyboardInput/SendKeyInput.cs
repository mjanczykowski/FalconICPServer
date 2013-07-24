using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace KeyboardInput
{
    public class SendKeyInput
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 SendInput(UInt32 nInputs, INPUT[] pInputs, Int32 cbSize);

        /// <summary>
        /// Simulates key down action by calling the WinAPI SendInput method.
        /// </summary>
        /// <param name="wScan">ScanCode of a key to press</param>
        public static void KeyDown(ScanCode wScan)
        {
            var input = new INPUT();
            input.type = (UInt32)InputType.KEYBOARD;
            var kInput = new KEYBDINPUT();
            kInput.wVk = 0;
            kInput.wScan = (UInt16)wScan;
            kInput.dwFlags = (UInt32)KeyboardFlag.SCANCODE;
            kInput.time = 0;
            kInput.dwExtraInfo = IntPtr.Zero;
            input.i.Keyboard = kInput;

            INPUT[] pInputs = new INPUT[1];
            pInputs[0] = input;

            var inputInsertionsCount = SendInput(1, pInputs, Marshal.SizeOf(typeof(INPUT)));

            if (inputInsertionsCount == 0) throw new InputInsertionFailedException(wScan.ToString());
        }

        /// <summary>
        /// Simulates key up action by calling the WinAPI SendInput method.
        /// </summary>
        /// <param name="wScan">ScanCode of a key to lift up</param>
        public static void KeyUp(ScanCode wScan)
        {
            var input = new INPUT();
            input.type = (UInt32)InputType.KEYBOARD;
            var kInput = new KEYBDINPUT();
            kInput.wVk = 0;
            kInput.wScan = (UInt16)wScan;
            kInput.dwFlags = (UInt32)KeyboardFlag.KEYUP + (UInt32)KeyboardFlag.SCANCODE;
            kInput.time = 0;
            kInput.dwExtraInfo = IntPtr.Zero;
            input.i.Keyboard = kInput;

            INPUT[] pInputs = new INPUT[1];
            pInputs[0] = input;

            var inputInsertionsCount = SendInput(1, pInputs, Marshal.SizeOf(typeof(INPUT)));

            if (inputInsertionsCount == 0) throw new InputInsertionFailedException(wScan.ToString());
        }

        /// <summary>
        /// Simulates key press by calling WinAPI SendInput with KeyDown and KeyUp events.
        /// </summary>
        /// <param name="wScan"></param>
        public static void KeyPress(ScanCode wScan)
        {
            INPUT[] pInputs = new INPUT[2];
            pInputs[0] = new INPUT();
            pInputs[0].type = (UInt32)InputType.KEYBOARD;
            var downInput = new KEYBDINPUT();
            downInput.wVk = 0;
            downInput.wScan = (UInt16)wScan;
            downInput.dwFlags = (UInt32)KeyboardFlag.SCANCODE;
            downInput.time = 0;
            downInput.dwExtraInfo = IntPtr.Zero;
            pInputs[0].i.Keyboard = downInput;

            pInputs[1] = new INPUT();
            pInputs[1].type = (UInt32)InputType.KEYBOARD;
            var upInput = new KEYBDINPUT();
            upInput.wVk = 0;
            upInput.wScan = (UInt16)wScan;
            upInput.dwFlags = (UInt32)KeyboardFlag.KEYUP + (UInt32)KeyboardFlag.SCANCODE;
            upInput.time = 0;
            upInput.dwExtraInfo = IntPtr.Zero;
            pInputs[1].i.Keyboard = upInput;

            var inputInsertionCount = SendInput(2, pInputs, Marshal.SizeOf(typeof(INPUT)));

            if (inputInsertionCount == 0) throw new InputInsertionFailedException(wScan.ToString());
        }


    }

    /// <summary>
    /// Exception thrown when none of the events have been successfully inserted into input.
    /// </summary>
    [Serializable]
    public class InputInsertionFailedException : Exception, ISerializable
    {
        public InputInsertionFailedException() { }

        public InputInsertionFailedException(string message) : base(message) { }

        public InputInsertionFailedException(string message, Exception innerException) : base(message, innerException) { }

        protected InputInsertionFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
