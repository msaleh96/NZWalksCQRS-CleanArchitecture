using Domain.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace API.Common;

public static class ResultExtensions
{
    public static IActionResult ToApiResponse<T>(this Result<T> result)
    {
        var response = new ApiResponse<T>
        {
            IsValid = result.IsSuccess,
            Errors = result.Errors.Select(e => new ApiError
            {
                Code = e.Code,
                Message = e.Description
            }).ToList(),
            Data = result.IsSuccess ? result.Value : default
        };

        return result.IsSuccess
            ? new OkObjectResult(response)
            : new BadRequestObjectResult(response);
    }

    public static ApiResponse<T> ToApiResponseBody<T>(this Result<T> result)
    {
        return new ApiResponse<T>
        {
            IsValid = result.IsSuccess,
            Errors = result.Errors.Select(e => new ApiError
            {
                Code = e.Code,
                Message = e.Description
            }).ToList(),
            Data = result.IsSuccess ? result.Value : default
        };
    }

    public static IActionResult ToCreatedResponse<T>(
        this Result<T> result,
        string routeName,
        Func<T, object> routeValues)
    {
        if (result.IsError)
            return new BadRequestObjectResult(result.ToApiResponseBody());

        return new CreatedAtRouteResult(
            routeName,
            routeValues(result.Value),
            result.ToApiResponseBody()
        );
    }
}