using ca_sln_2.Application.Common.Mappings;
using ca_sln_2.Domain.Entities;

namespace ca_sln_2.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
