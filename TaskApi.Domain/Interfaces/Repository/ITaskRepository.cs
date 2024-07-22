using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Entities;

namespace TaskApi.Domain.Interfaces.Repository
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
    }
}
