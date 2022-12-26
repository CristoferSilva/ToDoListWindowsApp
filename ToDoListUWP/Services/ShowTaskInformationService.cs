using Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoListUWP.Services
{
    public static class ShowTaskInformationService
    {

        public static readonly string Checked = $"\bIs Checked: ";
        public static readonly string Description = $"\n\bDescription: ";
        public static readonly string StartDate = $"\n\bStart Date: ";
        public static readonly string EndDate = $"\n\bEnd Date: ";


        public static async Task ShowTaskInformationDialog(TaskEntity taskEntity)
        {
            ContentDialog taskInformation = new ContentDialog
            {

                Title = $"\b{taskEntity.Title}".ToUpper(),
                Content = Checked + $"{taskEntity.IsChecked}" +
                          Description + $"{taskEntity.Description}" +
                          StartDate + $"{taskEntity.StartDate}" +
                          EndDate + $"{taskEntity.EndDate}",

                CloseButtonText = "Fechar",
            };
            taskInformation.CornerRadius = GetRadiusStyle();
            await taskInformation.ShowAsync();
        }

        private static CornerRadius GetRadiusStyle()
        {
            return new CornerRadius() { BottomLeft = 10, BottomRight = 10, TopLeft = 10, TopRight = 10 };
        }

    }
}
