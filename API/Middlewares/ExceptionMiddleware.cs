using Domain.Exceptions.EmailPasswordManagerExceptions;
using Domain.Exceptions.SitePasswordManagerExceptions;
using System.Net;
using System.Text.Json;

namespace API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var message = "";
        switch (ex)
        {
            case SiteExistsException exception:
                code = HttpStatusCode.BadRequest;
                message = JsonSerializer.Serialize(exception.Message);
                break;
            case EmailExistsException exception:
                code = HttpStatusCode.BadRequest;
                message = JsonSerializer.Serialize(exception.Message);
                break;
            case Exception exception:
                code = HttpStatusCode.InternalServerError;
                message = JsonSerializer.Serialize(exception.Message);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(message);
    }
}
