using Microsoft.AspNetCore.Diagnostics;
using Movies.Domain.Entities;

namespace Movies.API.Midlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        
        var response = new Result(exception.Message);

        httpContext.Response.StatusCode = 400;

        await httpContext.Response
            .WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}