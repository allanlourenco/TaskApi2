﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.Entities
{
    public class BaseEntityAudit : BaseEntityWithKey
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; }
    }

    public class BaseEntityWithKey : BaseEntity
    {
        public Guid Id { get; set; }
    }

    public class BaseEntity
    {

    }
}
