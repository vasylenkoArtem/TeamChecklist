using System.Text.Json;
using TeamChecklist.Domain.Exceptions;

namespace TeamChecklist.Filters;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            _logger.LogError(ex, "Domain exception occurred." + ex.Message); 
            await HandleDomainExceptionAsync(context, ex);  
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred." + ex.Message);  
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return context.Response.WriteAsync("An unexpected error occurred.");
    }

    private Task HandleDomainExceptionAsync(HttpContext context, DomainException exception)      
    {                                                                                
        context.Response.ContentType = "application/json";                           
        context.Response.StatusCode = StatusCodes.Status400BadRequest;                                                                                                                                                        
        return context.Response.WriteAsync(exception.Message);                                  
    }                                                                                
}