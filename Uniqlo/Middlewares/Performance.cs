using System.Diagnostics;

namespace Uniqlo.Middlewares
{
    public class Performance : IMiddleware
    {
        private readonly ILogger<Performance> _logger;

        public Performance(ILogger<Performance> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            const int performanceTimeLog = 500;

            var sw = new Stopwatch();

            sw.Start();

            await next(context);

            sw.Stop();

            if (performanceTimeLog < sw.ElapsedMilliseconds)
                _logger.LogWarning("Request {method} {path} it took about {elapsed} ms",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    sw.ElapsedMilliseconds);
        }
    }
}
