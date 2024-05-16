using Presentation.Dependency.Server.Models;

namespace Presentation.Dependency.Server.Services.Decorators
{
    public class TelemetricsDecorator: IPaymentProvider
    {
        private readonly IPaymentProvider _inner;
        private readonly ILogger<TelemetricsDecorator> _logger;

        public TelemetricsDecorator(ILogger<TelemetricsDecorator> logger, IPaymentProvider inner) 
        {
            _inner = inner;
            _logger = logger;
        }

        public PaymentResult Pay(decimal amount)
        {
            _logger.LogInformation("I have been intercepted {inner}", _inner.GetType());
            return _inner.Pay(amount);
        }
    }
}
