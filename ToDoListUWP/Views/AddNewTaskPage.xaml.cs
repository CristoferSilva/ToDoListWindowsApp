using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using ToDoListUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToDoListUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    [XmlType(TypeName = "AddNewTaskPage",
         Namespace = "ToDoListUWP")]

    public sealed partial class AddNewTaskPage : Page
    {
        public AddNewTaskViewModel ViewModel => (AddNewTaskViewModel)DataContext;
        public AddNewTaskPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            int taskId = int.Parse(((Object[])e.Parameter)[0].ToString());
           // int taskId = (int)e.Parameter;
            AppShell appShell = (AppShell)((Object[])e.Parameter)[1];
            DataContext = new AddNewTaskViewModel(taskId, appShell);
        }
    }
}
