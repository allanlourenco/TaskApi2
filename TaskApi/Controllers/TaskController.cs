using Microsoft.AspNetCore.Mvc;
using TaskApi.Domain.Entities;
using TaskApi.Domain.Interfaces.Services;

namespace TaskApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IQueueService queueService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, IQueueService queueService, ILogger<TaskController> logger)
        {
            this.taskService = taskService;
            this.queueService = queueService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<TaskEntity>> GetAllTasks()
        {
            try
            {
                _logger.LogInformation("Obtendo todas as tarefas.");
                var listTasks = await taskService.GetTasksAsync();
                
                return Ok(listTasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTask(Guid id)
        {
            try
            {
                _logger.LogInformation("Obtendo uma tarefa por ID.");
                var task = await taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<TaskEntity>> PostTask(TaskEntity task)
        {
            try
            {
                _logger.LogInformation("Adicionando uma tarefa.");
                await taskService.AddTaskAsync(task);
                await taskService.SaveTaskAsync();
                queueService.SendMessage($"Tarefa Criada: {task.Description}");
                return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, TaskEntity task)
        {
            try
            {
                _logger.LogInformation("Alterando uma tarefa.");
                if (id != task.Id)
                {
                    return BadRequest();
                }

                await taskService.UpdateTaskAsync(task);
                await taskService.SaveTaskAsync();
                queueService.SendMessage($"Tarefa Alterada: {task.Description}");
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                _logger.LogInformation("Deletando uma tarefa.");
                var task = await taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                await taskService.DeleteTaskAsync(task);
                await taskService.SaveTaskAsync();
                queueService.SendMessage($"Tarefa Deletada: {task.Description}");
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
