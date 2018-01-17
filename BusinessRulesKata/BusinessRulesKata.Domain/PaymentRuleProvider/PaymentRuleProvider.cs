using BusinessRulesKata.Domain.PaymentRule;
using BusinessRulesKata.Domain.PaymentRule.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRulesKata.Domain.PaymentRuleProvider
{
    public class PaymentRuleProvider : IPaymentRuleProvider
    {
        public List<IPaymentRule> GetAllRules()
        {
            List<IPaymentRule> rules = new List<IPaymentRule>();
            GetAllRuleTypes().ForEach(x => rules.Add((IPaymentRule)System.Activator.CreateInstance(x)));
            return rules;
        }

        public List<Type> GetAllRuleTypes()
        {
            return new List<Type>(){
                typeof(AnyMembershipRule),
                typeof(BookRule),
                typeof(LearningToSkiRule),
                typeof(MembershipActivationRule),
                typeof(MembershipUpgradeRule),
                typeof(PhysicalProductOrBookRule),
                typeof(PhysicalProductRule),
                typeof(VideoRule)
                };
        }
    }
}
