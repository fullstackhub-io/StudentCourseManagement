namespace CourseBasket.Application.Common.Behaviors
{
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            string userName = string.Empty;

            await Task.Run(() => _logger.LogInformation("UserManagement Request: {Name} {@UserName} {@Request}",
                    requestName, userName, request));
        }
    }
}
