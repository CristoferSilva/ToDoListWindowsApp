using Commons.Entities;
using Commons.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWPF.Model.Database;

namespace ToDoListWPF.ViewModels.Services
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
        public Task<List<TaskEntity>> GetAllTasks()
        {
            using (var database = new ToDoListDB())
            {
                return database.Tasks.ToListAsync();
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
            return list.Last();
        }

        public Task<List<TaskEntity>> GetAllTasksOfTheDay()
        {
            using (var database = new TasksDatabase())
            {
                var list = database.Tasks.ToListAsync().Result;
                var tasksOfTheDay = list.Where(taskEntity => taskEntity.EndDate == DateTime.Now || taskEntity.StartDate == DateTime.Now);
                return (Task<List<TaskEntity>>)tasksOfTheDay;
            }
        }
    }
}
