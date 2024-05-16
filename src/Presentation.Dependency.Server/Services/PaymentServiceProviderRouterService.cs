using Presentation.Dependency.Server.Models;

namespace Presentation.Dependency.Server.Services
{
    public interface IPaymentProviderRouter 
    {
        PaymentResult Pay(decimal amount);
    }

    public class PaymentServiceProviderRouterService : IPaymentProviderRouter, IScopedService
    {
        private IReadOnlyCollection<IPaymentProvider> _providers;

        public PaymentServiceProviderRouterService(IEnumerable<IPaymentProvider> providers) 
        {
            _providers = providers.ToList().AsReadOnly();
        }

        public PaymentResult Pay(decimal amount)
        {
            Random r = new Random(DateTime.Now.Second);
            var provider = _providers.ElementAt(r.Next(0, 2));
            return provider.Pay(amount);
        }
    }
}
