    using System.Net;
    using System.Text.Json;
    using CollegeERP.Domain.Exceptions;
namespace CollegeERP_.API.Middleware
{

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            switch (ex)
            {
                case DepartmentAlreadyExistsException:
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

            var payload = JsonSerializer.Serialize(new
            {
                error = message,
                status = (int)status
            });

            return context.Response.WriteAsync(payload);
        }
    }

}
