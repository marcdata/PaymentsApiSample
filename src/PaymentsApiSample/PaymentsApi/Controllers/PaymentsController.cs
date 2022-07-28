using Microsoft.AspNetCore.Mvc;
using PaymentsLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : Controller
    {
        IOneTimePaymentService _oneTimePaymentService;

        public PaymentsController(
            IOneTimePaymentService oneTimePaymentService
            )
        {
            _oneTimePaymentService = oneTimePaymentService ?? throw new ArgumentNullException(nameof(oneTimePaymentService));
        }

        [Route("/[controller]/one-time-payment")]
        [HttpPost]
        public async Task<IActionResult> OneTimePayment([FromHeader]int userId, [FromQuery]decimal amount)
        {
            return new OkObjectResult(await _oneTimePaymentService.PostPayment(userId, amount));
        }

    }
}
