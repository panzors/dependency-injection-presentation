namespace Presentation.Dependency.Server.Models
{
    public class PaymentModels
    {

    }

    public class PaymentResult
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
    }

    public class PaymentRequest
    {
        public decimal Amount { get; set; }
    }
}
