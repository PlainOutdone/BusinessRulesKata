using System;
using System.Collections.Generic;
using BusinessRulesKata.Domain.PostPaymentProcess;

namespace BusinessRulesKata.Domain.PaymentRuleProcessFactory
{
    public interface IPaymentRuleProcessFactory
    {
        List<IPostPaymentProcess> GetProcesses(Type passingRuleType);
    }
}