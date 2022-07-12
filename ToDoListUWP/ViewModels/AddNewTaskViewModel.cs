using Commons.Entities;
using Commons.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListUWP.Model;
using ToDoListUWP.Model.Commands;
using ToDoListUWP.ViewModels.Services;
using ToDoListUWP.Views;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoListUWP.ViewModels
{
    public class AddNewTaskViewModel : DependencyObject
    {

        public TaskEntity NewTask { get; set; }
        public AppShell CurrentAppShell { get; set; }
        public int NewTaskCount { get; private set; }
        public RepositoryService _respositoryService;
        public MessagePopUpService messagesPopUpService;
        public RelayCommand SaveNewTaskCommand { get; private set; }
        public RelayCommand CancelNewTaskCommand { get; private set; }
        public RelayCommand EditCurrentTaskCommand { get; private set; }


        public string Title { get; set; }
        public string Description { get; set; }

        private DateTimeOffset startDate;
        private DateTimeOffset endDate;
        public DateTimeOffset EndDate { get { return endDate; } set { endDate = value; } }
        public DateTimeOffset StartDate { get { return startDate; } set { startDate = value; } }


        public static readonly DependencyProperty EditFieldsEnableProperty =
            DependencyProperty.Register("EditFieldsEnable", typeof(bool), typeof(bool), new PropertyMetadata(0));

        public static readonly DependencyProperty ButtonEditEnableProperty =
            DependencyProperty.Register("ButtonEditEnable", typeof(bool), typeof(bool), new PropertyMetadata(0));


        public AddNewTaskViewModel(int id, AppShell appShell)
        {
            SaveNewTaskCommand = new RelayCommand(AddNewTask);
            CancelNewTaskCommand = new RelayCommand(ExitWindow);
            EditCurrentTaskCommand = new RelayCommand(EditCurrentTask);
            _respositoryService = new RepositoryService();
            messagesPopUpService = new MessagePopUpService(ExitWindow);
            CurrentAppShell = appShell;
            FillInTheFieldsIfTaskAlreadyExists(id);
        }

        private void FillInTheFieldsIfTaskAlreadyExists(int id)
        {
            if (CheckIfIdExisting(id).Result)
            {
                Title = NewTask.Title;
                Description = NewTask.Description;
                StartDate = (DateTimeOffset) NewTask.StartDate;
                EndDate = (DateTimeOffset) NewTask.EndDate;
            }
            else
            {
                StartDate = DateTimeOffset.Now;
                EndDate = DateTimeOffset.Now;
            }
        }

        private void EditCurrentTask()
        {
            EditFieldsEnable = true;
            ButtonEditEnable = !EditFieldsEnable;
        }

        private async void ExitWindow()
        {
            CurrentAppShell.RootFrame.Navigate(typeof(PresentationOfAllTasksView), new Object[] { CurrentAppShell });
        }

        private async Task<bool> CheckIfIdExisting(int id)
        {

            var wantedTask = await _respositoryService.GetTask(id);
            NewTask = wantedTask != null ? wantedTask : new TaskEntity();

            if (wantedTask == null)
            {
                EditFieldsEnable = true;
                ButtonEditEnable = !EditFieldsEnable;
                return false;
            }
            EditFieldsEnable = false;
            ButtonEditEnable = !EditFieldsEnable;
            return true;
        }

        public async void AddNewTask()
        {

            if (CheckIfIdExisting(NewTask.Id).Result)
            {
                await _respositoryService.RemoveTaskAsync(NewTask);
            }

            InitializeTaskProperties();

            try
            {
                await _respositoryService.AddNewTaskInDataBase(NewTask);
            }
            catch (Exception e)
            {
                await messagesPopUpService.showNotSuccessfulMessage();
                return;
            }

            await messagesPopUpService.showSuccessfulMessage();
            ExitWindow();

            
        }

        private async void InitializeTaskProperties()
        {
            try
            {
                NewTask.Id = _respositoryService.GetLastTaskIDInDataBase().Result + 1;
            }
            catch (Exception e)
            {
                NewTask.Id = 1;
            }
            NewTask.StartDate = StartDate.DateTime;
            NewTask.EndDate = EndDate.DateTime;
            NewTask.Title = Title;
            NewTask.Description = Description;
        }

        public bool EditFieldsEnable
        {
            get { return (bool)GetValue(EditFieldsEnableProperty); }
            set { SetValue(EditFieldsEnableProperty, value); }
        }

        public bool ButtonEditEnable
        {
            get { return (bool)GetValue(ButtonEditEnableProperty); }
            set { SetValue(ButtonEditEnableProperty, value); }
        }

    }
}
