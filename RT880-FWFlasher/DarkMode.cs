using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RT880_FWFlasher
{
    public static class DarkMode
    {
        const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20; // Use 19 for Windows 10 1809

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public static void EnableDarkMode(nint handle)
        {
            if (Environment.OSVersion.Version.Major >= 10)
            {
                int useDarkMode = 1;
                _ = DwmSetWindowAttribute(handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDarkMode, sizeof(int));
            }
        }
    }
}
