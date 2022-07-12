using Commons.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Services
{
    public class RepositoryService : ITaskRespositoryService
    {

        public async Task AddNewTaskInDataBase(TaskEntity newTask)
        {
            using (var database = new ToDoListDB())
            {
                database.Tasks.Add(newTask);
                await database.SaveChangesAsync();
            }
        }
        public async Task<List<TaskEntity>> GetAllTasks()
        {
            using (var database = new ToDoListDB())
            {
                var allTasks = await database.Tasks.ToListAsync();
                RemoveCheckedTasks(allTasks);
                AddRepositoryServiceInTaskEntities(allTasks);
                return allTasks;
            }
        }

        public async Task<bool> RemoveTaskAsync(TaskEntity newTask)
        {
            using (var database = new ToDoListDB())
            {
                try
                {
                    database.Tasks.Remove(newTask);
                    await database.SaveChangesAsync();

                }
                catch (Exception) { return false; }

                return true;
            }
        }

        public async Task<TaskEntity> GetLastTaskInDataBase()
        {
            List<TaskEntity> list = await GetAllTasks();
            RemoveCheckedTasks(list);
            return list.Last();
        }

        public async Task<List<TaskEntity>> GetAllTasksOfTheDay()
        {
            using (var database = new ToDoListDB())
            {

                var allTasks = await database.Tasks.ToListAsync();
                RemoveCheckedTasks(allTasks);
                RemoveTasksFromAnotherDay(allTasks);
                AddRepositoryServiceInTaskEntities(allTasks);
                return allTasks;
            }
        }

        private static void RemoveTasksFromAnotherDay(List<TaskEntity> allTasks)
        {
            foreach (TaskEntity currentTask in allTasks.ToList())
            {

                if (!(currentTask.EndDate.Day == DateTime.Now.Day && currentTask.EndDate.Month == DateTime.Now.Month) && !(currentTask.StartDate.Day == DateTime.Now.Day && currentTask.StartDate.Month == DateTime.Now.Month))
                {
                    allTasks.Remove(currentTask);
                }
            }

            RemoveCheckedTasks(allTasks);
        }

        private static void RemoveCheckedTasks(List<TaskEntity> allTasks)
        {
            foreach (TaskEntity currentTask in allTasks.ToList())
            {
                if (currentTask.IsChecked == true)
                {
                    allTasks.Remove(currentTask);
                }
            }
        }

        private void AddRepositoryServiceInTaskEntities(List<TaskEntity> taskEntities)
        {
            foreach (TaskEntity currentTask in taskEntities)
            {
                currentTask.RespositoryService = this;
            }
        }

        public async Task<TaskEntity> GetTask(int id)
        {
            using (var database = new ToDoListDB())
            {
                TaskEntity wantedTask = await database.Tasks.FindAsync(id);

                return wantedTask;
            }
        }

        public async Task<int> GetLastTaskIDInDataBase()
        {
            using (var database = new ToDoListDB())
            {
                List<TaskEntity> list = await database.Tasks.ToListAsync();
                return list.Last().Id;
            }
        }
    }
}
