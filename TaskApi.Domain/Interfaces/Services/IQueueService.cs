using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.Interfaces.Services
{
    public interface IQueueService
    {
        void SendMessage(string message);
    }
}
