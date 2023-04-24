using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace GPTAssistant.Features.functionality
{
    class GlobalHotkey : IDisposable
    {
        private const int WM_HOTKEY = 0x0312;

        int HOTKEY_ID;

        IntPtr handle;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public delegate void Method();

        private Method CalledMethod;

        public GlobalHotkey(IntPtr windowHandler, Method calledMethod, int MODKEY, int HOTKEY, int HOTKEY_ID)
        {
            CalledMethod = calledMethod;
            this.HOTKEY_ID = HOTKEY_ID;
            handle = windowHandler;

            bool result = RegisterHotKey(handle, HOTKEY_ID, MODKEY, HOTKEY);

            if (!result)
            {
                // Handle registration failure
            }

            ComponentDispatcher.ThreadPreprocessMessage += ThreadPreprocessMessageMethod;
        }

        private void ThreadPreprocessMessageMethod(ref MSG msg, ref bool handled)
        {
            if (msg.message == WM_HOTKEY && (int)msg.wParam == HOTKEY_ID)
            {
                CalledMethod();
            }
        }

        public void Dispose()
        {
            UnregisterHotKey(handle, HOTKEY_ID);
        }
        ~GlobalHotkey() 
        {
            UnregisterHotKey(handle, HOTKEY_ID);
        }
    }
}
