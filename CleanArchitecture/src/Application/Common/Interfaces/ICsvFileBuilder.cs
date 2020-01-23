using ca_sln_2.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace ca_sln_2.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
