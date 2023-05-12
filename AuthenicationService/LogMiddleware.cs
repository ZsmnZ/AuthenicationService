namespace AuthenicationService
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LogMiddleware(RequestDelegate next,ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.WriteEvent("IP адресс =>"+context.Connection.RemoteIpAddress.ToString());
            await _next(context);   
        }
    }
}
