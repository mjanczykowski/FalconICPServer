using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardInput
{
    /// <summary>
    /// Used by SendInput to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
    /// </summary>
    struct INPUT
    {
        /// <summary>
        /// The type of the input event. This member can be one of the following values.
        /// 
        /// Value:	                Meaning:
        /// InputType.Mouse         The event is a mouse event. Use the mi structure of the union.
        /// InputType.Keyboard      The event is a keyboard event. Use the ki structure of the union.
        /// InputType.Hardware      The event is a hardware event. Use the hi structure of the union.</summary>
        public UInt32 type;

        /// <summary>
        /// The information about a simulated event - MOUSEINPUT, KEYBDINPUT or HARDWAREINPUT struct
        /// </summary>
        public MKH_INPUT i;
    }
}
