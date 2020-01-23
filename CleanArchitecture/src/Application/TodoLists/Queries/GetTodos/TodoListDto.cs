using ca_sln_2.Application.Common.Mappings;
using ca_sln_2.Domain.Entities;
using System.Collections.Generic;

namespace ca_sln_2.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
