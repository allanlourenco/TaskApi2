using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Data.Context;
using TaskApi.Data.Repository;
using TaskApi.Domain.Entities;
using TaskApi.Domain.Interfaces.Repository;

namespace TaskApi.Data.Implementation
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
