using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Entities;
using TaskApi.Domain.Interfaces.Repository;
using TaskApi.Domain.Interfaces.Services;

namespace TaskApi.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        public Task AddTaskAsync(TaskEntity task)
        {
            return taskRepository.AddAsync(task);
        }

        public Task DeleteTaskAsync(TaskEntity task)
        {
            return taskRepository.DeleteAsync(task);
        }

        public Task<TaskEntity> GetTaskByIdAsync(Guid taskId)
        {
            return taskRepository.GetByIdAsync(taskId);
        }

        public Task<IEnumerable<TaskEntity>> GetTasksAsync()
        {
            return taskRepository.GetAllAsync();
        }

        public Task UpdateTaskAsync(TaskEntity task)
        {
            return taskRepository.UpdateAsync(task);
        }

        public Task SaveTaskAsync()
        {
            return taskRepository.SaveAsync();
        }
    }
}
