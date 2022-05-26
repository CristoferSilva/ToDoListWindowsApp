using Commons.Entities;
using Commons.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListUWP.Services
{
    public class RepositoryService : ITaskRespositoryService
    {
        public async Task AddNewTaskInDataBase(TaskEntity taskEntity)
        {
            using (var database = new ToDoListDB())
            {

                if ( await GetTask(taskEntity.Id) != null)
                {
                    await RemoveTaskAsync(taskEntity);
                    await database.SaveChangesAsync();

                }

                database.Tasks.Add(taskEntity);
                await database.SaveChangesAsync();
            }
        }
        public Task<List<TaskEntity>> GetAllTasks()
        {
            using (var database = new ToDoListDB())
            {
                Task<List<TaskEntity>> taskEntities = database.Tasks.ToListAsync();
                foreach (TaskEntity currentTask in taskEntities.Result)
                {
                    currentTask.RespositoryService = this;
                }

                return taskEntities;
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
            if (list.Count > 0)
            {
               return list.Last();
            }
            throw new Exception("Database is empty");
        }

        public async Task<TaskEntity> GetTask(int id)
        {
            using (var database = new ToDoListDB())
            {
                TaskEntity wantedTask = await database.Tasks.FindAsync(id);
               
                return wantedTask;
            }
        }

    }
}
