using BusinessRulesKata.Domain.BusinessLogicMapper;
using BusinessRulesKata.Domain.PaymentRule.Rules;
using BusinessRulesKata.Domain.PostPaymentProcess;
using BusinessRulesKata.Domain.PostPaymentProcess.Processes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesKata.Domain.PaymentRuleProcessFactory
{
    /// <summary>
    /// https://stackoverflow.com/questions/708911/using-case-switch-and-gettype-to-determine-the-object
    /// 
    /// Intention was to say, if i'm x rule, return y processes
    /// apparently this is harder than it should be due to types 
    /// and all the solutions have a code smell in my optiion
    /// </summary>
    /// 
    public class PaymentRuleProcessFactory : IPaymentRuleProcessFactory
    {
        private Dictionary<Type, int> _typeDict = new Dictionary<Type, int>
            {
            {typeof(BookRule),0},
            {typeof(LearningToSkiRule),1},
            {typeof(MembershipActivationRule),2},
            {typeof(MembershipUpgradeRule),3 },
            {typeof(PhysicalProductOrBookRule),4 },
            {typeof(PhysicalProductRule),5 },
            {typeof(VideoRule),6},
             {typeof(AnyMembershipRule),7}
        };

        public List<IPostPaymentProcess> GetProcesses(Type passingRuleType, IBusinessLogicMapper mapper)
        {

            List<IPostPaymentProcess> _returnList = new List<IPostPaymentProcess>();
            switch (_typeDict[passingRuleType])
            {
                case 0: //book rule
                    _returnList.Add(new GeneratePackingSlipProcess(mapper));
                    break;
                case 1: //learning to ski rule
                    break;
                case 2: //membership activation rule
                    break;
                case 3: //membership upgrade rule
                    break;
                case 4: //physical product or book rule
                    break;
                case 5: //physical product rule
                    _returnList.Add(new GeneratePackingSlipProcess(mapper));
                    break;
                case 6: //video rule
                    break;
                case 7: //any membership rule
                    break;
                default:
                    throw new NotImplementedException();
            }
            return _returnList;
        }
    }
}