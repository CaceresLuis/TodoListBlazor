using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.web.Services.Contracts;

namespace TodoListBlazor.web.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateTodo(AddTodoDto todoDto)
        {
            await _httpClient.PostAsJsonAsync("api/todo", todoDto);
        }

        public async Task<List<TodoDto>> ListTodo()
        {
            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync("api/Todo");
                if (!response.IsSuccessStatusCode)
                {
                    string? messaje = await response.Content.ReadAsStringAsync();
                    throw new Exception(messaje);
                }

                return await response.Content.ReadFromJsonAsync<List<TodoDto>>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TodoDto> GetTodo(Guid id)
        {
            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync($"api/todo/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    string? messaje = await response.Content.ReadAsStringAsync();
                    throw new Exception(messaje);
                }
                return await response.Content.ReadFromJsonAsync<TodoDto>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateTodo(TodoDto todoDto)
        {

            string? jsonRequest = JsonConvert.SerializeObject(todoDto);
            StringContent? content = new(jsonRequest, Encoding.UTF8, "application/json-patch+json");
            HttpResponseMessage? response = await _httpClient.PutAsync($"api/todo/{todoDto.Id}", content);

            string? error = await response.Content.ReadAsStringAsync();
            if (error.Contains("Task does exist"))
            {
                throw new Exception("Error: Task does exist");
            }
        }

        public async Task DeleteTodo(Guid id)
        {
            HttpResponseMessage? response = await _httpClient.DeleteAsync($"api/todo/{id}");
            if (!response.IsSuccessStatusCode)
            {
                string? error = await response.Content.ReadAsStringAsync();
                if (error.Contains("Task does exist"))
                {
                    throw new Exception("Error: Task does exist");
                }
            }
            Console.WriteLine("wenale :D");
        }
    }
}
