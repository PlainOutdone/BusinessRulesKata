using BusinessRulesKata.Domain.PaymentRule;
using BusinessRulesKata.Models;
using System;
using Xunit;

namespace BusinessRulesKata.UnitTests.PaymentRule
{
    public class PaymentRuleValidator
    {


        public void ValidateAllRules(Payment payment, PaymentRuleTestBuilder builder)
        {
            foreach (Type type in builder.GetPassingTypes())
            {
                IPaymentRule rule = (IPaymentRule)System.Activator.CreateInstance(type);
                Assert.True(rule.IsValid(payment));
            }

            foreach (Type type in builder.GetFailingTypes())
            {
                IPaymentRule rule = (IPaymentRule)System.Activator.CreateInstance(type);
                Assert.False(rule.IsValid(payment));
            }
        }
    }
}
