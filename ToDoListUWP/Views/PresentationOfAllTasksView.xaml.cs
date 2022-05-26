using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using ToDoListUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoListUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    [XmlType(TypeName = "PresentationOfAllTasksView",
         Namespace = "ToDoListUWP.Views")]
    public sealed partial class PresentationOfAllTasksView : Page
    {
        public PresentationOfAllTasksViewModel ViewModel => (PresentationOfAllTasksViewModel)DataContext;

        public PresentationOfAllTasksView()
        {
            DataContext = new PresentationOfAllTasksViewModel();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            AppShell appShell = (AppShell)((Object[])e.Parameter)[0];
            DataContext = new PresentationOfAllTasksViewModel(appShell);
            base.OnNavigatedTo(e);  
        }
    }
}
