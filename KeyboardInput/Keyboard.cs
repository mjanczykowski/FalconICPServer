﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KeyboardInput
{
    public static class Keyboard
    {
        /// <summary>
        /// Determines whether a key is up or down at the time the function is called, and whether 
        /// the key was pressed after a previous call to GetAsyncKeyState. 
        /// </summary>
        /// <remarks>
        /// The GetAsyncKeyState function works with mouse buttons. However, it checks on the state 
        /// of the physical mouse buttons, not on the logical mouse buttons that the physical buttons 
        /// are mapped to. For example, the call GetAsyncKeyState(VK_LBUTTON) always returns the state 
        /// of the left physical mouse button, regardless of whether it is mapped to the left or right 
        /// logical mouse button. You can determine the system's current mapping of physical mouse buttons 
        /// to logical mouse buttons by calling GetSystemMetrics(SM_SWAPBUTTON).
        /// 
        /// which returns TRUE if the mouse buttons have been swapped.
        /// 
        /// Although the least significant bit of the return value indicates whether the key has been 
        /// pressed since the last query, due to the pre-emptive multitasking nature of Windows, another 
        /// application can call GetAsyncKeyState and receive the "recently pressed" bit instead of your 
        /// application. The behavior of the least significant bit of the return value is retained strictly 
        /// for compatibility with 16-bit Windows applications (which are non-preemptive) and should not be 
        /// relied upon.
        /// 
        /// You can use the virtual-key code constants VK_SHIFT, VK_CONTROL, and VK_MENU as values for the 
        /// vKey parameter. This gives the state of the SHIFT, CTRL, or ALT keys without distinguishing 
        /// between left and right.
        /// 
        /// You can use the following virtual-key code constants as values for vKey to distinguish between 
        /// the left and right instances of those keys.
        /// Code:	    Meaning:
        /// VK_LSHIFT	Left-shift key.
        /// VK_RSHIFT	Right-shift key.
        /// VK_LCONTROL	Left-control key.
        /// VK_RCONTROL	Right-control key.
        /// VK_LMENU	Left-menu key.
        /// VK_RMENU	Right-menu key.
        /// 
        /// These left- and right-distinguishing constants are only available when you call 
        /// the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions. 
        /// </remarks>
        /// <param name="vKey">The virtual-key code. For more information, see Virtual Key Codes.
        /// You can use left- and right-distinguishing constants to specify certain keys. See the Remarks 
        /// section for further information.</param>
        /// <returns>If the function succeeds, the return value specifies whether the key was pressed since 
        /// the last call to GetAsyncKeyState, and whether the key is currently up or down. If the most 
        /// significant bit is set, the key is down, and if the least significant bit is set, the key was 
        /// pressed after the previous call to GetAsyncKeyState. However, you should not rely on this last 
        /// behavior; for more information, see the Remarks.
        /// 
        /// The return value is zero for the following cases:
        /// - The current desktop is not the active desktop
        /// - The foreground thread belongs to another process and the desktop does not allow the hook 
        /// or the journal record.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern Int16 GetAsyncKeyState(Int32 vKey);

        /// <summary>
        /// Checks if given key is currently down or not.
        /// </summary>
        /// <param name="vKey">VirtualKeyCode of key to check</param>
        /// <returns>True if given key is down or false otherwise.</returns>
        public static bool IsKeyDown(VirtualKeyCode vKey)
        {
            short result = GetAsyncKeyState((int)vKey);

            result >>= 15;
            return ((result & 1) == 1);
        }
        
    }
}
