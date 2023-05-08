using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ToDoListWPF.Views.Dictionaries
{
    public class Resources : ResourceDictionary
    {
        private void OnMouseClick(object obj, MouseButtonEventArgs args)
        {
            MessageBox.Show("Double clicked!");
        }
    }
}
