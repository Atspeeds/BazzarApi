using Bazzar.Core.ApplicationService.Advertisements.CommadnHandlers;
using Bazzar.Core.Domain.Advertisements.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bazzar.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddvertismentController : ControllerBase
    {


        [HttpPost]
        public IActionResult Post([FromServices] CreateHandler handler, Create request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("title")]
        [HttpPut]
        public IActionResult Put([FromServices] SetTitleHandler handler, SetTitle request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateTextHandler handler, UpdateText request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("price")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdatePriceHandler handler, UpdatePrice request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("publish")]
        [HttpPut]
        public IActionResult Put([FromServices] RequestToPublishHandler handler, RequestToPublish request)
        {
            handler.Handle(request);
            return Ok();
        }
    }
}
