using AutoMapper;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Api.Data.Entities;

namespace TodoListBlazor.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<Todo, AddTodoDto>().ReverseMap();
        }
    }
}
