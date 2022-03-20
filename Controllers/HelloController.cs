using System.Net;
using asp_mediatr_example.Commands;
using asp_mediatr_example.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace asp_mediatr_example.Controllers;

[ApiController]
[Route("[controller]/hello")]
public class HelloController : ControllerBase
{
    private readonly ILogger<HelloController> _logger;
    private readonly IMediator _mediator;

    public HelloController(ILogger<HelloController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "Create Hello Message")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Create([FromBody] HelloCreateRequest helloCreateRequest, CancellationToken cancellationToken)
    {
        var helloCommand = new HelloCommand(helloCreateRequest.Name);
        var result = await _mediator.Send(helloCommand, cancellationToken);
        if(!result){
            return BadRequest();
        }
        return Accepted();
    }
    [HttpPost("empty", Name = "Create Hello Message Without Handler")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> CreateWithoutHandler([FromBody] HelloCreateRequest helloCreateRequest, CancellationToken cancellationToken)
    {
        var helloCommand = new HelloNoHandlerCommand(helloCreateRequest.Name);
        var result = await _mediator.Send(helloCommand, cancellationToken);
        if(!result){
            return BadRequest();
        }
        return Accepted();
    }

    [HttpPost("noti", Name = "Create Hello Notification Message")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Noti([FromBody] HelloCreateRequest helloCreateRequest, CancellationToken cancellationToken)
    {
        var helloCommand = new HelloNotification(helloCreateRequest.Name);
        await _mediator.Publish(helloCommand, cancellationToken);
        return Accepted();
    }

    [HttpPost("noti-empty", Name = "Create Hello Notification Message without receiver")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> NotiEmpty([FromBody] HelloCreateRequest helloCreateRequest, CancellationToken cancellationToken)
    {
        var helloCommand = new HelloNoHandlerNotification(helloCreateRequest.Name);
        await _mediator.Publish(helloCommand, cancellationToken);
        return Accepted();
    }
}