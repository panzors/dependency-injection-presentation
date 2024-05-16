using Presentation.Dependency.Server.Models;

namespace Presentation.Dependency.Server.Services
{
    public class ScroogeMcduckBankPaymentProvider : IPaymentProvider, IScopedService
    {
        private readonly IDatabaseService _database;
        public ScroogeMcduckBankPaymentProvider(IDatabaseService database)
        {
            _database = database;
        }

        public PaymentResult Pay(decimal amount)
        {
            var result = new PaymentResult
            {
                Amount = amount - 0.01m,
                Details = "Paid with a handling fee",
            };
            
            _database.AddPayment(result);
            return result;
        }
    }

    public class PixelPayPaymentProvider : IPaymentProvider, IScopedService
    {
        private readonly IDatabaseService _database;

        public PixelPayPaymentProvider(IDatabaseService database)
        {
            _database = database;
        }

        public PaymentResult Pay(decimal amount)
        {
            var result = new PaymentResult
            {
                Amount = amount,
                Details = "Handled by Pixelpay",
            };
            _database.AddPayment(result);

            return result;
        }
    }
}
