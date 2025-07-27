using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml;
using PInvoke;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void SpinIcons(NavigationView navView)
        {
            foreach (var item in navView.MenuItems.OfType<NavigationViewItem>())
            {
                if (item.Icon is FontIcon fontIcon)
                {
                    // 회전 transform이 없으면 추가
                    if (fontIcon.RenderTransform == null)
                    {
                        fontIcon.RenderTransform = new RotateTransform() { CenterX = 12, CenterY = 12 };
                    }

                    // 스토리보드 생성
                    var rotate = new DoubleAnimation()
                    {
                        From = 0,
                        To = 720,
                        Duration = new Duration(TimeSpan.FromMilliseconds(500)),
                        EasingFunction = new SineEase()
                    };

                    var storyboard = new Storyboard();
                    Storyboard.SetTarget(rotate, fontIcon);
                    Storyboard.SetTargetProperty(rotate, "(UIElement.RenderTransform).(RotateTransform.Angle)");
                    storyboard.Children.Add(rotate);
                    storyboard.Begin();
                }
            }
        }
    }
}
