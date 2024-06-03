using System.Net;

namespace E_Learning.Error
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;

        public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //context.Response.ContentType = "application/json";

                var response = _environment.IsDevelopment() ? new ApiExceptionResponse((int)HttpStatusCode.InternalServerError
                    , e.Message, e.StackTrace) : new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);

                //var json = JsonSerializer.Serialize(response , new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

                //await context.Response.WriteAsync(json); 
                await context.Response.WriteAsJsonAsync(response);




            }


        }
    }
}
