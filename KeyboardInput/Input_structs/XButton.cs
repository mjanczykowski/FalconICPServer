using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardInput
{
    /// <summary>
    /// XButton values for MouseData field in <see cref="MOUSEINPUT"/> structure.
    /// </summary>
    public enum XButton : uint
    {
        /// <summary>
        /// Set if the first X button is pressed or released.
        /// </summary>
        XBUTTON1 = 0x0001,
        /// <summary>
        /// Set if the second X button is pressed or released.
        /// </summary>
        XBUTTON2 = 0x0002,
    }
}
