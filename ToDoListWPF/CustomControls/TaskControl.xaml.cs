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

namespace WPFToDoList.UserControls
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TaskControl), new PropertyMetadata(string.Empty));

        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(TaskControl), new PropertyMetadata(DateTime.Now));

        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register("EndDate", typeof(DateTime), typeof(TaskControl), new PropertyMetadata(DateTime.Now));

        public TaskControl()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler TaskCheck
        {
            add { AddHandler(TaskCheckEvent, value); }
            remove { RemoveHandler(TaskCheckEvent, value); }
        }

        public static readonly RoutedEvent TaskCheckEvent = EventManager.RegisterRoutedEvent(nameof(TaskCheck), RoutingStrategy.Bubble ,typeof(RoutedEventHandler), typeof(TaskControl)); //Chama o evento em outros elementos da DOM

        private void CheckBoxTask_Checked(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(TaskCheckEvent));
        }

        public event RoutedEventHandler TaskClick
        {
            add { AddHandler(TaskClickEvent, value); }
            remove { RemoveHandler(TaskClickEvent, value); }
        }

        public static readonly RoutedEvent TaskClickEvent = EventManager.RegisterRoutedEvent(nameof(TaskClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TaskControl)); //Chama o evento em outros elementos da DOM

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RaiseEvent(new RoutedEventArgs(TaskClickEvent));
        }
    }
}
