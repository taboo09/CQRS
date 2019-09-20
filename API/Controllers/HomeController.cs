using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Home;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeDto>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ActionResult<HomeDto>> Register(Create.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}