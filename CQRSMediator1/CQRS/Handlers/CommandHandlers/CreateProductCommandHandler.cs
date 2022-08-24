using CQRSMediator1.CQRS.Commands.Request;
using CQRSMediator1.CQRS.Commands.Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator1.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private AppDbContext context;
        public CreateProductCommandHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Products()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now
            };
            context.Products.Add(product);

            await this.context.SaveChangesAsync();
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
