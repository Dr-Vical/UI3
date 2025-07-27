using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Test1.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Test1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this); // ��� â ������ �ҷ��� ����
            IconHelper.SetWindowIcon(hwnd, "Assets\\pie_chart_icon.ico"); // ����
        }
        private void MainNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {

                string tag = selectedItem.Tag?.ToString();
                switch (tag)
                {
                    case "Main":
                        MainContent.Content = new Controls.ucMain();
                        break;
                    case "Manual":
                        MainContent.Content = new Controls.ucManual();
                        break;
                    case "Recipe":
                        MainContent.Content = new Controls.ucRecipe();
                        break;
                    case "IO":
                        MainContent.Content = new Controls.ucIO();
                        break;
                    case "Error":
                        MainContent.Content = new Controls.ucError();
                        break;
                    case "Settings":
                        MainContent.Content = new Controls.ucSetting();
                        break;

                }
            }
        }

        private async void MainNav_PaneOpening(NavigationView sender, object args)
        {
            var dialog = new Controls.MyDialog
            {
                XamlRoot = this.Content.XamlRoot // �� �ʿ��� �κ�!
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                // �� ������ �� ������ ����
                // ��: MessageBox ��Ÿ���� �˸�
                var confirm = new ContentDialog
                {
                    Title = "Ȯ�ε�",
                    Content = "�����ǰ� �����Ǿ����ϴ�!",
                    CloseButtonText = "Ȯ��",
                    XamlRoot = this.Content.XamlRoot
                };
                await confirm.ShowAsync();
            }
        }
    }
}
