using System;
using System.Collections.Generic;
using System.Text;
using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.PaymentRule.Rules
{
    public class LearningToSkiRule : IPaymentRule
    {
        public bool IsValid(Payment payment)
        {
            return (payment.Type == PaymentType.Video && payment.Reference == "Learning to Ski" && payment.DateRequested.Year > 1997);
        }
    }
}
