using BusinessRulesKata.Domain.BusinessLogicMapper;
using BusinessRulesKata.Domain.PaymentRule;
using BusinessRulesKata.Domain.PaymentRuleProcessFactory;
using BusinessRulesKata.Domain.PaymentRuleProvider;
using BusinessRulesKata.Domain.PostPaymentProcess;
using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.PaymentRuleController
{
    public class PaymentRuleController : IPaymentRuleController
    {

        IPaymentRuleProvider _provider;
        IPaymentRuleProcessFactory _processFactory;
        public PaymentRuleController(IPaymentRuleProvider provider, IPaymentRuleProcessFactory processFactory)
        {
            _provider = provider;
            _processFactory = processFactory;
        }

        public void RunPostPaymentLogic(Payment payment, IBusinessLogicMapper mapper)
        {
            foreach (IPaymentRule rule in _provider.GetAllRules())
            {
                if (rule.IsValid(payment))
                {
                    foreach (IPostPaymentProcess process in _processFactory.GetProcesses(rule.GetType(),mapper))
                    {
                        process.Process(payment);
                    }
                }
            }
        }

    }

}
