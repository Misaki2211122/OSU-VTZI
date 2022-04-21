using System.ComponentModel;
using Application.Domains.Requests.Math;
using Application.Domains.Requests.Test;
using Application.Domains.Responses.Math;
using Application.Domains.Responses.Test;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Math;

[ApiController]
[Route("/math/")]
[DisplayName("Управление пользователями")]
[Produces("application/json")]
public class MathController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// ChatController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public MathController(IMediator mediator)
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
    [Route("summMetod")] // название метода для обращения 
    [SwaggerResponse(StatusCodes.Status200OK, "Получение информации", typeof(SummMetodRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Возврат информации", typeof(SummMetodResponse))]
    public async Task<IActionResult> SummMetod([FromForm] SummMetodRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    } 
    
    /*/// <summary>
    /// Тестовый метод для начала работы получает TestRequest Ctrl + лкм перйти к классу
    /// Отдает TestResponse Ctrl + лкм перйти к классу
    /// </summary>
    /// <param name="request">Данные получаемые с фронта</param>
    /// <returns></returns>
    [HttpPost]
    [Route("newMetod")] // название метода для обращения 
    [SwaggerResponse(StatusCodes.Status200OK, "Получение информации", typeof(TestRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Возврат информации", typeof(TestResponse))]
    public async Task<IActionResult> NewMetod([FromForm] TestRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }*/
}