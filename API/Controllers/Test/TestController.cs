using Application.Domains.Requests.User;
using Application.Domains.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers.Test;

[ApiController]
[Authorize("BasicPolicy")]
[Route("/users/")]
[DisplayName("Управление пользователями")]
[Produces("application/json")]
public class TestController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public TestController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpPost]
    [Route("getInfo")]
    [AllowAnonymous]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение инфформации", typeof(TestRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание пользователя", typeof(TestResponse))]
    public async Task<IActionResult> CreateUser([FromHeader] string SC_Authorization,
        [FromForm] GetInfoRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }

}