using ProductsAPI.Exceptions;

namespace ProductsAPI
{
    public class ErrorHandligMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandligMiddleware> _logger;

        public ErrorHandligMiddleware(ILogger<ErrorHandligMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                _ = context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                _ = context.Response.WriteAsync("Something wrong!");
                
            }
        }
    }
}
