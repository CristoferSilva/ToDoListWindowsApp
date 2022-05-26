using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFToDoList.Model.Database;

namespace WPFToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            intializeDatabase();
            MainWindow = new MainWindow();
            MainWindow.Show();
        }

        private async static void intializeDatabase()
        {
            using (var db = new TaskDatabase())
            {
                await db.Database.EnsureCreatedAsync();
            }
        }
    }
}
