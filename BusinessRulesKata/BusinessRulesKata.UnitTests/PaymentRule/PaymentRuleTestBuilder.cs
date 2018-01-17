using BusinessRulesKata.Domain.PaymentRule.Rules;
using BusinessRulesKata.Domain.PaymentRuleProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRulesKata.UnitTests.PaymentRule
{
    public class PaymentRuleTestBuilder
    {

        private List<Type> _allRuleTypes = new PaymentRuleProvider().GetAllRuleTypes();
       
        private List<Type> _passingTypes = new List<Type>();
        public PaymentRuleTestBuilder AddPassingRule(Type type)
        {
            _passingTypes.Add(type);
            return this;
        }

        public List<Type> GetPassingTypes()
        {
            return _passingTypes;
        }

        public List<Type> GetFailingTypes()
        {
            return _allRuleTypes.Where(t => !_passingTypes.Contains(t)).ToList();
        }
    }
}
