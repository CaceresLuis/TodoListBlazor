using TodoListBlazor.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using TodoListBlazor.web.Services.Contracts;
using TodoListBlazor.Shared.Enums;

namespace TodoListBlazor.web.Pages
{
    public class CreateTodoBase : ComponentBase
    {
        [Inject]
        public ITodoService TodoService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string State { get; set; }
        public string Complete { get; set; }
        public string Do { get; set; }
        public string Doing { get; set; }
        public string Failed { get; set; }

        public async Task CreateTodo()
        {
            Console.WriteLine(State);
            AddTodoDto todoDto = new()
            {
                Title = Title,
                TodoState = State,
                Description = Description,
                IsCompleted = IsCompleted
            };
            if (IsCompleted || Complete != null)
            {
                todoDto.IsCompleted = true;
                todoDto.TodoState = "Complete";
            }
            else if(!IsCompleted)
                todoDto.IsCompleted = false;

            await TodoService.CreateTodo(todoDto);
            NavigationManager.NavigateTo("/");
        }
    }
}
