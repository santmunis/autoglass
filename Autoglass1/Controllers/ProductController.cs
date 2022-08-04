using System.Threading.Tasks;
using Api.Base;
using Domain.Product.Command;
using Domain.Product.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand.Contract request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await Send(request);
            return result;

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(DeleteProductCommand.Contract request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await Send(request);
            return result;

        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateProductCommand.Contract request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await Send(request);
            return result;

        }
       
        [HttpGet()]
        public async Task<IActionResult> GetByIdStudent(GetProductByIdQuery.Contract request)
        {
            var result = await Send(request);
            return result;

        }
    }
}
