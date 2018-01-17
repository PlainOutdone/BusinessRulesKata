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
        IBusinessLogicMapper _mapper;
        IPaymentRuleProcessFactory _processFactory;
        public PaymentRuleController(IPaymentRuleProvider provider, IBusinessLogicMapper mapper, IPaymentRuleProcessFactory processFactory)
        {
            _provider = provider;
            _mapper = mapper;
            _processFactory = processFactory;
        }

        public void RunPostPaymentLogic(Payment payment)
        {
            foreach (IPaymentRule rule in _provider.GetAllRules())
            {
                if (rule.IsValid(payment))
                {
                    foreach (IPostPaymentProcess process in _processFactory.GetProcesses(rule.GetType()))
                    {
                        process.Process(payment);
                    }
                }
            }
        }

    }

}
