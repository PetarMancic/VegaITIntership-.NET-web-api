using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Middleware;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
         _logger.LogInformation( $"Incoming request: {context.Request.Method} {context.Request.Path}");
        
        // Logujemo headers
        foreach (var header in context.Request.Headers)
        {
            _logger.LogDebug($"🔹 Header: {header.Key} = {header.Value}");
        }

        // Logujemo body (ako postoji i ako je JSON/XML/text)
        if (context.Request.Body.CanRead && 
            (context.Request.ContentType?.Contains("application/json") == true || 
             context.Request.ContentType?.Contains("text/") == true))
        {
            context.Request.EnableBuffering(); // Omogućava višestruko čitanje body-ja
            
            using (var reader = new StreamReader(
                context.Request.Body, 
                Encoding.UTF8, 
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(body))
                {
                    _logger.LogInformation( $"📦 Request Body: {body}");
                }
                
                // Vraćamo stream na početak da bi sledeći middleware mogao da čita
                context.Request.Body.Position = 0;
            }
        }

        // Prosljeđujemo request dalje u pipeline
        await _next(context);

        // Logujemo response status nakon obrade
        _logger.LogInformation($"⬆️ Response Status: {context.Response.StatusCode}");

        
    }
}
