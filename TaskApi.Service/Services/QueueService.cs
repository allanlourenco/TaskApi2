using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Interfaces.Services;

namespace TaskApi.Service.Services
{
    public class QueueService : IQueueService
    {
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "taskQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: "taskQueue", basicProperties: null, body: body);
            }
        }
    }
}
