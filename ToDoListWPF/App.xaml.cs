using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDoListWPF.Model;

namespace ToDoListWPF
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
