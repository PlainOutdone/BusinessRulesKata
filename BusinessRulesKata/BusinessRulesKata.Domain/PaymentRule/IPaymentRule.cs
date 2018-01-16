using BusinessRulesKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesKata.Domain.PaymentRule
{
    public interface IPaymentRule
    {
        bool IsValid(Payment payment);
    }
}
