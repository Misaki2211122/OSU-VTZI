using System.ComponentModel;
using Application.Domains.Requests.Test;
using Application.Domains.Responses.Test;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Test;

[ApiController]
[Route("/test/")]
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

    /// <summary>
    /// Тестовый метод для начала работы получает TestRequest Ctrl + лкм перйти к классу
    /// Отдает TestResponse Ctrl + лкм перйти к классу
    /// </summary>
    /// <param name="request">Данные получаемые с фронта</param>
    /// <returns></returns>
    [HttpPost]
    [Route("testMetod")] // название метода для обращения 
    [SwaggerResponse(StatusCodes.Status200OK, "Получение информации", typeof(TestRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Возврат информации", typeof(TestResponse))]
    public async Task<IActionResult> TestMetod([FromForm] TestRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}