using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Test1.Models;

namespace Test1.ViewModels
{
     class MainVM : ObservableObject
    {
        public ObservableCollection<Btn_Model> Buttons { get; set; }

        public MainVM()
        {
            Buttons = new ObservableCollection<Btn_Model>();

            for (int i = 1; i <= 10; i++)
            {
                int index = i;
                Buttons.Add(new Btn_Model
                {
                    Text = $"Hello {i}",
                    Command = new RelayCommand(() => OnButtonClick(index))
                });
            }
        }

        private void OnButtonClick(int index)
        {
            System.Diagnostics.Debug.WriteLine($"Button {index} 클릭됨");
        }
    }
}