using System;
using System.Collections.Generic;
using System.Text;
using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.PaymentRule.Rules
{
    public class PhysicalProductOrBookRule : IPaymentRule
    {
        public bool IsValid(Payment payment)
        {
            return (payment.Type == PaymentType.Book || payment.Type == PaymentType.PhysicalProduct);
        }
    }
}
