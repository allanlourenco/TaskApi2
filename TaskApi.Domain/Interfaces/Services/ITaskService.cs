using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Entities;

namespace TaskApi.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> GetTasksAsync();
        Task<TaskEntity> GetTaskByIdAsync(Guid taskId);
        Task AddTaskAsync(TaskEntity task);
        Task UpdateTaskAsync(TaskEntity task);
        Task DeleteTaskAsync(TaskEntity task);
        Task SaveTaskAsync();
    }
}
