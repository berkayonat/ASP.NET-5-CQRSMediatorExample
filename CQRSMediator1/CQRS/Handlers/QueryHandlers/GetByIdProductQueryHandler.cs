using CQRSMediator1.CQRS.Commands.Request;
using CQRSMediator1.CQRS.Queries.Response;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator1.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly AppDbContext context;
        public GetByIdProductQueryHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = this.context.Products.FirstOrDefault(p => p.Id == request.Id);
            return new GetByIdProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
