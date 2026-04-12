using API.Common;
using Application.Images.Commands.UploadImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadImageController(IMediator mediator) : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string description)
    {

        var command = new UploadImageCommand(
            file.OpenReadStream(),
            file.FileName,
            description);

        var result = await mediator.Send(command);

        return result.ToApiResponse();
    }
}