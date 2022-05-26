using Commons.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commons.Services
{
    public interface ITaskRespositoryService
    {
        Task AddNewTaskInDataBase(TaskEntity newTask);
        Task<List<TaskEntity>> GetAllTasks();
        Task<TaskEntity> GetLastTaskInDataBase();
        Task<bool> RemoveTaskAsync(TaskEntity newTask);
    }
}