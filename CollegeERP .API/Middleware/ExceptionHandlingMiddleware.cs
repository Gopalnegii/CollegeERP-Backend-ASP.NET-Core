    using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs;
    using System.Net;
    using System.Text.Json;
namespace CollegeERP_.API.Middleware
{

    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;
        
        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is not DomainException)
                {
                    _logger.LogError(ex, "Unhandled system exception occurred");
                }

                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            switch (ex)
            {
                case ValidationException vex:
                    status = HttpStatusCode.BadRequest;

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)status;

                    var response = new ApiErrorResponse
                    {
                        Error = vex.Message,
                        Status = (int)status,
                        Details = vex.Errors,
                        traceId = context.TraceIdentifier
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    return;
                case AlreadyExistsException:
                    status = HttpStatusCode.Conflict;   // 409
                    message = ex.Message;
                    break;

                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;   // 404
                    message = ex.Message;
                    break;

                case ArgumentException:
                    status = HttpStatusCode.BadRequest; // 400
                    message = ex.Message;
                    break;

                default:
                    status = HttpStatusCode.InternalServerError; // 500
                    message = "An unexpected error occurred.";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            var payload = new ApiErrorResponse { Error = message, Status = (int)status,traceId=context.TraceIdentifier };

                await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
            return; 
        }
    }

}
