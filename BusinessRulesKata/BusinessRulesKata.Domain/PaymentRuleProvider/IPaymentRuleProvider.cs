using System;
using System.Collections.Generic;
using BusinessRulesKata.Domain.PaymentRule;

namespace BusinessRulesKata.Domain.PaymentRuleProvider
{
    public interface IPaymentRuleProvider
    {
        List<IPaymentRule> GetAllRules();
        List<Type> GetAllRuleTypes();
    }
}