using Commons.Entities;
using Commons.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListUWP.Model;
using ToDoListUWP.Services;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoListUWP.ViewModels
{
    public class PresentationOfAllTasksViewModel : DependencyObject
    {

        private TaskEntity _selectedTask;
        public AppShell CurrentAppShell { get; set; }
        private RepositoryService _respositoryService;
        public List<TaskEntity> AllTasks { get; set; }

        public TaskEntity SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                ListView_SelectionChanged();
            }
        }


        public PresentationOfAllTasksViewModel()
        {
            _respositoryService = new RepositoryService();
            AllTasks = new List<TaskEntity>();
            InitAllTaskList();
        }

        public PresentationOfAllTasksViewModel(AppShell currentAppShell)
        {
            _respositoryService = new RepositoryService();
            AllTasks = new List<TaskEntity>();
            CurrentAppShell = currentAppShell;
            InitAllTaskList();
        }

        private async void InitAllTaskList()
        {
            AllTasks = await _respositoryService.GetAllTasks();
        }

        public async void ListView_SelectionChanged()
        {
            CurrentAppShell.RootFrame.Navigate(typeof(AddNewTaskPage), new Object[] { _selectedTask.Id, CurrentAppShell  });
        }
    }
}
