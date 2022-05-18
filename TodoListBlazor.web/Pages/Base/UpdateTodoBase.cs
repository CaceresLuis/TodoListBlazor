using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Shared.Enums;
using Microsoft.AspNetCore.Components;
using TodoListBlazor.web.Services.Contracts;

namespace TodoListBlazor.web.Pages
{
    public class UpdateTodoBase : ComponentBase
    {
        [Inject]
        public ITodoService TodoService { get; set; }
        [Parameter]
        public Guid Id { get; set; }
        public TodoDto Todo { get; set; }
        public List<string> States { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string State;

        protected override async Task OnInitializedAsync()
        {
            Todo = await TodoService.GetTodo(Id);
            States = Enum.GetNames(typeof(State)).ToList();
        }

        protected async Task UpdateTodo(TodoDto todoDto)
        {
            if (todoDto.IsCompleted || todoDto.TodoState == "Complete")
            {
                todoDto.TodoState = "Complete";
                todoDto.IsCompleted = true;
            }
            else if (!todoDto.IsCompleted)
            {
                todoDto.TodoState =  "Do";
            }
           await TodoService.UpdateTodo(todoDto);
            NavigationManager.NavigateTo("/");
        }

        public void OnStaleSelected(string value)
        {
            State = value;
        }
    }
}
