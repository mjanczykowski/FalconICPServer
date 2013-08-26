using System;
using System.Runtime.InteropServices;

namespace F4KeyFile
{
    [Flags]
    [Serializable]
    [ComVisible(true)]
    public enum KeyModifiers
    {
        None = 0,
        Shift = 1,
        Ctrl = 2,
        ShiftControl = 3,
        Alt = 4,
        ShiftAlt = 5,
        CtrlAlt = 6,
        ShiftCtrlAlt = 7
    }
}