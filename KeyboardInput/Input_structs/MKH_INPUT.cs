using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KeyboardInput
{
    /// <summary>
    /// Structure emulating union field for INPUT struct.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    struct MKH_INPUT
    {
        [FieldOffset(0)]
        public MOUSEINPUT Mouse;

        [FieldOffset(0)]
        public KEYBDINPUT Keyboard;

        [FieldOffset(0)]
        public HARDWAREINPUT Hardware;
    }
}
