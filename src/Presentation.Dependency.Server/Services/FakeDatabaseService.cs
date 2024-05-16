using Presentation.Dependency.Server.Models;

namespace Presentation.Dependency.Server.Services
{
    public interface IDatabaseService
    {
        PaymentResult GetPayment(int id);
        int AddPayment(PaymentResult payment);
    }

    public class FakeDatabaseService : IDatabaseService, ISingletonService
    {
        public List<PaymentResult> _data = new List<PaymentResult>();

        public int AddPayment(PaymentResult payment)
        {
            var id = _data.Count + 1;
            payment.Id = id;
            _data.Add(payment);
            return id;
        }

        public PaymentResult GetPayment(int id)
        {
            return _data.Single(x => x.Id == id);
        }
    }
}
