using BusinessRulesKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesKata.Domain.PaymentRuleController
{
    public interface IPaymentRuleController
    {
        void RunPostPaymentLogic(Payment payment);
    }

}
