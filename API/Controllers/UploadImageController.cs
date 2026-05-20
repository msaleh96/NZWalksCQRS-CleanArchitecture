using API.Common;
using API.Requests.UploadImage;
using Application.Features.Images.Commands.UploadImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadImageController(IMediator mediator) : ControllerBase
{
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload([FromForm] UploadImageRequest request)
    {

        var command = new UploadImageCommand(
            request.File.OpenReadStream(),
            request.File.FileName,
            request.Description);

        var result = await mediator.Send(command);

        return result.ToApiResponse();
    }
}