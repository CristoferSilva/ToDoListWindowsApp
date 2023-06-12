using Commons.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using ToDoListUWP.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoListUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    [XmlType(TypeName = "AppShell",
         Namespace = "ToDoListUWP")]
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ApplicationView.lau = new Size(610,950);
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            if (!string.IsNullOrEmpty(e.Parameter.ToString()))
            {

                if (((Object[])e.Parameter)[0].Equals(EnumViewNames.AddNewTaskPage))
                {
                    RootFrame.Navigate(typeof(AddNewTaskPage), new Object[] { ((Object[])e.Parameter)[1], this });
                    appShellTitle.Text = "Add new Task";
                }
                else 
                { 
                    RootFrame.Navigate(typeof(PresentationOfAllTasksView), new Object[] { this });
                    appShellTitle.Text = "Task History";
                }

            }

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}




/*  if (!string.IsNullOrEmpty(e.Parameter.ToString()))
  {
      decoderEntries = new WwwFormUrlDecoder(e.Parameter.ToString());

      if (decoderEntries.ToList().Count == 1 && decoderEntries[0].Value == "AddNewTaskPage")
      {
          RootFrame.Navigate(typeof(AddNewTaskPage), new Object[] { -1, this });
      }
      else if (decoderEntries.ToList().Count == 2 && decoderEntries[0].Value == "AddNewTaskPage")
      {
          RootFrame.Navigate(typeof(AddNewTaskPage), new Object[] { decoderEntries[1].Value, this });

      }

      RootFrame.Navigate(typeof(PresentationOfAllTasksView), new Object[] { this });
  }*/

