﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardInput
{
#pragma warning disable 649
    /// <summary>
    /// Contains information about a simulated mouse event.
    /// </summary>
    /// <remarks>
    /// If the mouse has moved, indicated by MOUSEEVENTF_MOVE, dxand dy specify information about that movement. The information is specified as absolute or relative integer values.
    /// 
    /// If MOUSEEVENTF_ABSOLUTE value is specified, dx and dy contain normalized absolute coordinates between 0 and 65,535. The event procedure maps these coordinates onto the display surface. Coordinate (0,0) maps onto the upper-left corner of the display surface; coordinate (65535,65535) maps onto the lower-right corner. In a multimonitor system, the coordinates map to the primary monitor.
    /// 
    /// If MOUSEEVENTF_VIRTUALDESK is specified, the coordinates map to the entire virtual desktop.
    /// 
    /// If the MOUSEEVENTF_ABSOLUTE value is not specified, dxand dy specify movement relative to the previous mouse event (the last reported position). Positive values mean the mouse moved right (or down); negative values mean the mouse moved left (or up).
    /// 
    /// Relative mouse motion is subject to the effects of the mouse speed and the two-mouse threshold values. A user sets these three values with the Pointer Speed slider of the Control Panel's Mouse Properties sheet. You can obtain and set these values using the SystemParametersInfo function.
    /// 
    /// The system applies two tests to the specified relative mouse movement. If the specified distance along either the x or y axis is greater than the first mouse threshold value, and the mouse speed is not zero, the system doubles the distance. If the specified distance along either the x or y axis is greater than the second mouse threshold value, and the mouse speed is equal to two, the system doubles the distance that resulted from applying the first threshold test. It is thus possible for the system to multiply specified relative mouse movement along the x or y axis by up to four times.
    /// </remarks>
    struct MOUSEINPUT
    {
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved. 
        /// </summary>
        public Int32 dx;
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved. 
        /// </summary>
        public Int32 dy;
        /// <summary>
        /// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then mouseData should be zero.
        /// 
        /// If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were pressed or released. This value may be any combination of the following flags.
        /// 
        /// Value	    Meaning
        /// XBUTTON1    Set if the first X button is pressed or released.
        /// XBUTTON2    Set if the second X button is pressed or released.</summary>
        public UInt32 mouseData;
        /// <summary>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can be any reasonable combination of the following values.
        /// 
        /// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions. For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed, but not for subsequent motions. Similarly, MOUSEEVENTF_LEFTUP is set only when the button is first released.
        /// 
        /// You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags simultaneously in the dwFlags parameter, because they both require use of the mouseData field.
        /// 
        /// Value	Meaning
        /// MOUSEEVENTF_ABSOLUTE            The dx and dy members contain normalized absolute coordinates. If the flag is not set, dxand dy contain relative data (the change in position since the last reported position). This flag can be set, or not set, regardless of what kind of mouse or other pointing device, if any, is connected to the system. For further information about relative mouse motion, see the following Remarks section.
        /// MOUSEEVENTF_HWHEEL              The wheel was moved horizontally, if the mouse has a wheel. The amount of movement is specified in mouseData.
        ///                                 Windows XP/2000:  This value is not supported.
        /// MOUSEEVENTF_MOVE                Movement occurred.
        /// MOUSEEVENTF_MOVE_NOCOALESCE     The WM_MOUSEMOVE messages will not be coalesced. The default behavior is to coalesce WM_MOUSEMOVE messages.
        ///                                 Windows XP/2000:  This value is not supported.
        /// MOUSEEVENTF_LEFTDOWN            The left button was pressed.
        /// MOUSEEVENTF_LEFTUP              The left button was released.
        /// MOUSEEVENTF_RIGHTDOWN           The right button was pressed.
        /// MOUSEEVENTF_RIGHTUP             The right button was released.
        /// MOUSEEVENTF_MIDDLEDOWN          The middle button was pressed.
        /// MOUSEEVENTF_MIDDLEUP            The middle button was released.
        /// MOUSEEVENTF_VIRTUALDESK         Maps coordinates to the entire desktop. Must be used with MOUSEEVENTF_ABSOLUTE.
        /// MOUSEEVENTF_WHEEL               The wheel was moved, if the mouse has a wheel. The amount of movement is specified in mouseData.
        /// MOUSEEVENTF_XDOWN               An X button was pressed.
        /// MOUSEEVENTF_XUP                 An X button was released.</summary>
        public UInt32 dwFlags;
        /// <summary>
        /// The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp. 
        /// </summary>
        public UInt32 time;
        /// <summary>
        /// An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information. 
        /// </summary>
        public IntPtr dwExtraInfo;
    }
#pragma warning restore 649
}
