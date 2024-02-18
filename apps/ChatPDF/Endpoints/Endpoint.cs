using Codefastly.ChatPDF.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Codefastly.ChatPDF.Endpoints;

[ApiController]
public abstract class Endpoint : ControllerBase
{
    protected IActionResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            // ReSharper disable once SuspiciousTypeConversion.Global
            IValidationResult validationResult =>
                BadRequest(CreateProblemDetails(
                    "Validation Error",
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.Errors
                )),
            _ =>
                BadRequest(CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error
                ))
        };
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null
    )
    {
        return new ProblemDetails
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
    }
}