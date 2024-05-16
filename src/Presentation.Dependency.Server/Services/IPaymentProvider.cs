using Presentation.Dependency.Server.Models;

namespace Presentation.Dependency.Server.Services
{
    public interface IPaymentProvider
    {
        public PaymentResult Pay(decimal amount);
    }
}
