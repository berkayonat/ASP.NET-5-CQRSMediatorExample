using CQRSMediator1.CQRS.Queries.Response;
using MediatR;

namespace CQRSMediator1.CQRS.Commands.Request
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
