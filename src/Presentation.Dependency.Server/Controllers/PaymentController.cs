using Microsoft.AspNetCore.Mvc;
using Presentation.Dependency.Server.Models;
using Presentation.Dependency.Server.Services;

namespace Presentation.Dependency.Server.Controllers
{
    [Route("[controller]")]
    public class PaymentController: ControllerBase
    {
        [HttpPost]
        [Route("pay")]
        public PaymentResult Pay(
            [FromBody] PaymentRequest paymentRequest, 
            [FromServices] IPaymentProviderRouter paymentProvider) 
        {
            return paymentProvider.Pay(paymentRequest.Amount);
        }

        [HttpGet]
        [Route("paymentdetails/{id}")]
        public PaymentResult GetPaymentDetails(
            [FromRoute]int id, 
            [FromServices] IDatabaseService fakeDatabase)
        {
            return fakeDatabase.GetPayment(id);
        }
    }
}
