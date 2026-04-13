using API.Common;
using Application.Images.Commands.UploadImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadImageController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string description)
    {

        var command = new UploadImageCommand(
            file.OpenReadStream(),
            file.FileName,
            description);

        return await Send(command);
    }
}