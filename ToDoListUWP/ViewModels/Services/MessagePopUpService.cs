using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListUWP.Model.Commands;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoListUWP.ViewModels.Services
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
            await contentDialog.ShowAsync();
        }
        public async Task showNotSuccessfulMessage()
        {
            ContentDialog contentDialog = new ContentDialog { Title = $"Save Information".ToUpper(), Content = "save was not successful!", CloseButtonCommand = ExitWindowCommand, CloseButtonText = "Close" };
            contentDialog.CornerRadius = cornerRadius;

            await contentDialog.ShowAsync();
        }
    }
}
