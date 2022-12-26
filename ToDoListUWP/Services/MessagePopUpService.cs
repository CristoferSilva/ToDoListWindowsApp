using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListUWP.Model.Commands;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ToDoListUWP.Services
{
    public class MessagePopUpService
    {
        public RelayCommand ExitWindowCommand { get; private set; }

        private CornerRadius cornerRadius { get; set; }
        public MessagePopUpService(Action exitWindowAction)
        {
            cornerRadius = new CornerRadius() { BottomLeft = 10, BottomRight = 10, TopLeft = 10, TopRight = 10 };
            ExitWindowCommand = new RelayCommand(exitWindowAction);
        }
        public async Task showSuccessfulMessage()
        {
            ContentDialog contentDialog = new ContentDialog { Title = $"Save Information".ToUpper(), Content = "Save was successful!", CloseButtonCommand = ExitWindowCommand, CloseButtonText = "Close"};
            contentDialog.CornerRadius = cornerRadius;
            contentDialog.Background = new SolidColorBrush(Colors.LightSkyBlue);

            await contentDialog.ShowAsync();

        }
        public async Task showNotSuccessfulMessage()
        {
            ContentDialog contentDialog = new ContentDialog { Title = $"Save Information".ToUpper(), Content = "Save was not successful!", CloseButtonCommand = ExitWindowCommand, CloseButtonText = "Close"};
            contentDialog.CornerRadius = cornerRadius;
            contentDialog.Background = new SolidColorBrush(Colors.IndianRed);

            await contentDialog.ShowAsync();
        }
    }
}
