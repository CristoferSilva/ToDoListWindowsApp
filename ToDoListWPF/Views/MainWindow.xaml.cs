using Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoListWPF.ViewModels;
using ToDoListWPF.UserControls;

namespace ToDoListWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool wasItCheckedEvent = false;

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        private void TaskControl_TaskClick(object sender, RoutedEventArgs e)
        {
            if (!wasItCheckedEvent)
            {
                TaskEntity clickedTask = (TaskEntity)((TaskControl)sender).DataContext;
                ((MainWindowViewModel)DataContext).TaskClick(clickedTask);
            } else
            {
                wasItCheckedEvent = !wasItCheckedEvent;
            }
        }

        private void TaskControl_TaskCheck(object sender, RoutedEventArgs e)
        {
            wasItCheckedEvent = !wasItCheckedEvent;

            //TODO Link a method for this event
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void WindowCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
