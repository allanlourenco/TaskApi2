using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Enums;

namespace TaskApi.Domain.Entities
{
    public class TaskEntity : BaseEntityAudit
    {
        public string Description { get; set; } = string.Empty;
        public StatusTask Status { get; set; }
    }
}
