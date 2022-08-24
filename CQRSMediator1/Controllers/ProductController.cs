using CQRSMediator1.CQRS.Commands.Request;
using CQRSMediator1.CQRS.Commands.Response;
using CQRSMediator1.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSMediator1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

    }
}
