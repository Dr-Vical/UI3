using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PInvoke;

namespace Test1.Helpers
{

    public static class IconHelper
    {
        public static void SetWindowIcon(IntPtr hwnd, string IconPath) // 두가지가 필요. intptr, 경로
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, IconPath); // 베이스 + 파일 경로

            if (!File.Exists(fullPath))
            {
                System.Diagnostics.Debug.WriteLine($"아이콘 파일 없음: {fullPath}");
                return;
            }

            var hIcon = User32.LoadImage(IntPtr.Zero, fullPath, 
                          User32.ImageType.IMAGE_ICON, 0, 0,
                          User32.LoadImageFlags.LR_LOADFROMFILE); // 외부에서 파일을 직접 불러옴

            // ICON_BIG (1), ICON_SMALL (0) 모두 설정
            User32.SendMessage(hwnd, User32.WindowMessage.WM_SETICON, (IntPtr)1, hIcon);
            User32.SendMessage(hwnd, User32.WindowMessage.WM_SETICON, (IntPtr)0, hIcon);

        }
    }
}
