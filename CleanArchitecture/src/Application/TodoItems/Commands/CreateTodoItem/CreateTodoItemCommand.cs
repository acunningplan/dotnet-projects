using ca_sln_2.Application.Common.Interfaces;
using ca_sln_2.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ca_sln_2.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<long>
    {
        public int ListId { get; set; }

        public string Title { get; set; }

        public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateTodoItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
            {
                var entity = new TodoItem
                {
                    ListId = request.ListId,
                    Title = request.Title,
                    Done = false
                };

                _context.TodoItems.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
