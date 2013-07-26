using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KeyboardInput
{
    public static class KeyCodeConverter
    {
        /// <summary>
        /// Translates (maps) a virtual-key code into a scan code or character value, or translates
        /// a scan code into a virtual-key code. The function translates the codes using the input 
        /// language and an input locale identifier.
        /// </summary>
        /// <remarks>
        /// The input locale identifier is a broader concept than a keyboard layout, since it can also 
        /// encompass a speech-to-text converter, an Input Method Editor (IME), or any other form of input.
        /// 
        /// An application can use MapVirtualKeyEx to translate scan codes to the virtual-key code constants 
        /// VK_SHIFT, VK_CONTROL, and VK_MENU, and vice versa. These translations do not distinguish between 
        /// the left and right instances of the SHIFT, CTRL, or ALT keys.
        /// 
        /// An application can get the scan code corresponding to the left or right instance of one of these 
        /// keys by calling MapVirtualKeyEx with uCode set to one of the following virtual-key code constants.
        /// 
        /// VK_LSHIFT
        /// VK_RSHIFT
        /// VK_LCONTROL
        /// VK_RCONTROL
        /// VK_LMENU
        /// VK_RMENU
        /// 
        /// These left- and right-distinguishing constants are available to an application only through 
        /// the GetKeyboardState, SetKeyboardState, GetAsyncKeyState, GetKeyState, MapVirtualKey, and 
        /// MapVirtualKeyEx functions. For list complete table of virtual key codes, see Virtual Key Codes. 
        /// </remarks>
        /// <param name="uCode">The virtual-key code or scan code for a key. How this value is 
        /// interpreted depends on the value of the uMapType parameter.
        /// 
        /// Starting with Windows Vista, the high byte of the uCode value can contain either 
        /// 0xe0 or 0xe1 to specify the extended scan code.</param>
        /// <param name="uMapType">The translation to perform. The value of this parameter 
        /// depends on the value of the uCode parameter. </param>
        /// <param name="dwhkl">Input locale identifier to use for translating the specified code. 
        /// This parameter can be any input locale identifier previously returned by the LoadKeyboardLayout 
        /// function. </param>
        /// <returns>The return value is either a scan code, a virtual-key code, or a character value, 
        /// depending on the value of uCode and uMapType. If there is no translation, the return value 
        /// is zero.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 MapVirtualKeyEx(UInt32 uCode, UInt32 uMapType, IntPtr dwhkl);

        /// <summary>
        /// Retrieves the active input locale identifier (formerly called the keyboard layout).
        /// </summary>
        /// <remarks>
        /// The input locale identifier is a broader concept than a keyboard layout, since it can also 
        /// encompass a speech-to-text converter, an Input Method Editor (IME), or any other form of input.
        /// 
        /// Since the keyboard layout can be dynamically changed, applications that cache information about 
        /// the current keyboard layout should process the WM_INPUTLANGCHANGE message to be informed 
        /// of changes in the input language.
        /// 
        /// To get the KLID (keyboard layout ID) of the currently active HKL, call the GetKeyboardLayoutName.
        /// 
        /// Beginning in Windows 8: The preferred method to retrieve the language associated with 
        /// the current keyboard layout or input method is a call to Windows.Globalization.Language.CurrentInputMethodLanguageTag. 
        /// If your app passes language tags from CurrentInputMethodLanguageTag to any National Language 
        /// Support functions, it must first convert the tags by calling ResolveLocaleName.
        /// </remarks>
        /// <param name="idThread">The identifier of the thread to query, or 0 for the current thread. </param>
        /// <returns>The return value is the input locale identifier for the thread. The low word 
        /// contains a Language Identifier for the input language and the high word contains a device 
        /// handle to the physical layout of the keyboard.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetKeyboardLayout(UInt32 idThread);

        /// <summary>
        /// Returns handle to current keyboard layout of active window.
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetKeybdLayout()
        {
            return GetKeyboardLayout(0);
        }

        /// <summary>
        /// Converts VirtualCode to ScanCode using layout of active window.
        /// </summary>
        /// <param name="vk"></param>
        /// <returns></returns>
        public static ScanCode VirtualCodeToScanCode(VirtualKeyCode vk)
        {
            var sc = MapVirtualKeyEx((uint)vk, (uint)MapType.MAPVK_VK_TO_VSC_EX, GetKeybdLayout());

            if ((sc >> 8) == 0xe0)
            {
                sc -= 0xe000;
                Console.WriteLine(vk.ToString());
            }
            else if ((sc >> 8) == 0xe1)
            {
                sc -= 0xe100;
                Console.WriteLine(vk.ToString());
            }
            

            switch (vk)
            {
                case VirtualKeyCode.LEFT:
                case VirtualKeyCode.RIGHT:
                case VirtualKeyCode.UP:
                case VirtualKeyCode.DOWN:
                case VirtualKeyCode.HOME:
                case VirtualKeyCode.INSERT:
                case VirtualKeyCode.DELETE:
                case VirtualKeyCode.END:
                case VirtualKeyCode.NEXT:
                case VirtualKeyCode.PRIOR:
                case VirtualKeyCode.NUMLOCK:
                case VirtualKeyCode.RCONTROL:
                case VirtualKeyCode.RMENU:
                case VirtualKeyCode.LWIN:
                case VirtualKeyCode.RWIN:
                case VirtualKeyCode.DIVIDE:
                case VirtualKeyCode.APPS:
                case VirtualKeyCode.PAUSE:
                    sc |= 0x80;
                    break;
                case VirtualKeyCode.RSHIFT:
                    sc = 54;
                    break;
            }
            return (ScanCode)sc;
        }

        /// <summary>
        /// Map type for MapVirualKeyEx function. The translation to perform. The value of this
        /// parameter depends on the value of the uCode parameter. 
        /// </summary>
        public enum MapType : uint {
            /// <summary>
            /// The uCode parameter is a virtual-key code and is translated into an unshifted 
            /// character value in the low order word of the return value. Dead keys (diacritics) 
            /// are indicated by setting the top bit of the return value. If there is no translation, 
            /// the function returns 0.
            /// </summary>
            MAPVK_VK_TO_CHAR = 2,
            /// <summary>
            /// The uCode parameter is a virtual-key code and is translated into a scan code. 
            /// If it is a virtual-key code that does not distinguish between left- and right-hand 
            /// keys, the left-hand scan code is returned. If there is no translation, the function 
            /// returns 0.
            /// </summary>
            MAPVK_VK_TO_VSC = 0,
            /// <summary>
            /// The uCode parameter is a virtual-key code and is translated into a scan code. 
            /// If it is a virtual-key code that does not distinguish between left- and right-hand 
            /// keys, the left-hand scan code is returned. If the scan code is an extended scan code, 
            /// the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended 
            /// scan code. If there is no translation, the function returns 0.
            /// </summary>
            MAPVK_VK_TO_VSC_EX = 4,
            /// <summary>
            /// The uCode parameter is a scan code and is translated into a virtual-key code that does
            /// not distinguish between left- and right-hand keys. If there is no translation, the function
            /// returns 0. 
            /// </summary>
            MAPVK_VSC_TO_VK = 1,
            /// <summary>
            /// The uCode parameter is a scan code and is translated into a virtual-key code that 
            /// distinguishes between left- and right-hand keys. If there is no translation, the function
            /// returns 0. 
            /// </summary>
            MAPVK_VSC_TO_VK_EX = 3
        }
    }
}
