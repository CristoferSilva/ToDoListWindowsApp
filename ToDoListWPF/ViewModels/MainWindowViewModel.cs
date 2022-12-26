using Commons.Entities;
using Commons.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFToDoList.Model.Commands;
using WPFToDoList.Services;

namespace WPFToDoList.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<TaskEntity> _taskList;

        public List<TaskEntity> TaskList
        {
            get { return _taskList; }
            set { _taskList = value; NotifyPropertyChanged("TaskList"); }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private TaskEntity selectedTask;
        public RepositoryService respositoryService;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand OpenListCommad { get; private set; }
        public RelayCommand AddNewTaskCommad { get; private set; }

        public TaskEntity SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
            }
        }


        public MainWindowViewModel()
        {
            TaskList = new List<TaskEntity>();
            respositoryService = new RepositoryService();
            RefreshCommand = new RelayCommand(InitializeTaskList);
            AddNewTaskCommad = new RelayCommand(ShowAddNewTaskView);
            OpenListCommad = new RelayCommand(ShowPresentationsOfAllTasksView);
            InitializeTaskList();
        }

        public void InitializeTaskList()
        {
            try
            {
                //TaskList = respositoryService.GetAllTasks().Result;
                TaskList = respositoryService.GetAllTasksOfTheDay().Result;
                if (TaskList.Count == 0)
                {
                    DefaultTaskList();
                }
            }
            catch (Exception)
            {
                DefaultTaskList();

            }
        }

        private void DefaultTaskList()
        {
            TaskList = new List<TaskEntity>(){ new TaskEntity()
                {
                    Title = "Welcome, There is nothing today!",
                    IsChecked = false,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                } };
        }

        public void TaskClick(TaskEntity sender)
        {
            OpenUWPViews.ShowAddNewTaskView(sender);
        }
        public void ShowAddNewTaskView()
        {
            OpenUWPViews.ShowAddNewTaskView();
        }
        public void ShowPresentationsOfAllTasksView()
        {
            OpenUWPViews.ShowPresentationsOfAllTasksView();
        }
    }
}
