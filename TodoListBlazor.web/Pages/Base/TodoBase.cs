using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Shared.Enums;
using Microsoft.AspNetCore.Components;
using TodoListBlazor.web.Services.Contracts;

namespace TodoListBlazor.web.Pages
{
    public class TodoBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ITodoService TodoService { get; set; }
        public List<TodoDto> Todos { get; set; }
        public List<string> States { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Todos = await TodoService.ListTodo();
            States = Enum.GetNames(typeof(State)).ToList();
        }   
    }
}
