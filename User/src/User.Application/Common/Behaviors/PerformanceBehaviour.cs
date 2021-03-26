namespace User.Application.Common.Behaviors
{
    using global::User.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly IConfigConstants _constact;

        public PerformanceBehaviour(ILogger<TRequest> logger, IConfigConstants constants)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _constact = constants;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > _constact.LongRunningProcessMilliseconds)
            {
                var requestName = typeof(TRequest).Name;
                var userName = string.Empty;
                _logger.LogWarning("UserManagement Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserName} {@Request}",
                    requestName, elapsedMilliseconds, userName, request);
            }

            return response;
        }
    }
}
