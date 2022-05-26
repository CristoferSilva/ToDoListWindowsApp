using Commons.Entities;
using Commons.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoListWPF.Commands;
using ToDoListWPF.ViewModels.Services;

namespace ToDoListWPF.ViewModels
{
    public class MainWindowViewModel
    {
        private TaskEntity selectedTask;
        public RepositoryService respositoryService;
        public List<TaskEntity> TasksList { get; set; }
        public RelayCommand RefreshCommad { get; private set; }
        public RelayCommand OpenListCommad { get; private set; }
        public RelayCommand AddNewTaskCommad { get; private set; }

        public TaskEntity SelectedTask
        {
            get { return selectedTask; }
            set 
            {
                selectedTask = value;
                ListView_SelectionChanged();
            }
        }


        public MainWindowViewModel()
        {
            TasksList = new List<TaskEntity>();
            AddNewTaskCommad =  new RelayCommand(AddNewList);
            respositoryService = new RepositoryService();
            TasksList = new List<TaskEntity>();
            InitializeTaskList();
        }

        public void AddNewList(object parameter)
        {
            Process.Start("com.todolistuwp://");
        }
 
        public async void InitializeTaskList()
        {
            try
            {
                TasksList = await respositoryService.GetAllTasksOfTheDay();
            }
            catch (Exception)
            {

            TasksList = new List<TaskEntity>();

            }
        }

        public void ListView_SelectionChanged()
        {

        }
    }
}
