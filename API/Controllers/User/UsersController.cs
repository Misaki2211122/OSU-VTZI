using System.ComponentModel;
using Application.Domains.Requests.User;
using Application.Domains.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.User;

[ApiController]
[Authorize("BasicPolicy")]
[Route("/users/")]
[DisplayName("Управление пользователями")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public UsersController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    
    [HttpPost]
    [Route("getInfo")]
    [AllowAnonymous]
    [SwaggerResponse(StatusCodes.Status200OK, "Получение инфформации", typeof(GetInfoRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Создание пользователя", typeof(GetInfoResponse))]
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