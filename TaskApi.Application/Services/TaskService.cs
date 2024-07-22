using System.Net.Http;
using System.Net.Http.Json;
using TaskApi.Application.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskApi.Application.Services
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiTask");
        }

        public async Task<List<Models.Task>> GetTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Models.Task>>("api/task");
        }

        public async Task<Models.Task> GetTaskByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Models.Task>($"api/task/{id}");
        }

        public async Task AddTaskAsync(Models.Task task)
        {
            await _httpClient.PostAsJsonAsync("api/task", task);
        }

        public async Task UpdateTaskAsync(Models.Task task)
        {
            await _httpClient.PutAsJsonAsync($"api/task/{task.Id}", task);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/task/{id}");
        }
    }
}
