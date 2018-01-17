using BusinessRulesKata.Domain;
using BusinessRulesKata.Domain.BusinessLogicMapper;
using BusinessRulesKata.Domain.PaymentRuleController;
using BusinessRulesKata.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BusinessRulesKata.IntegrationTests
{
    public class PaymentRuleControllerTests
    {
        [Fact]
        public static void WhenProvidedAPaymentForABookEnsureThePackingSlipProcessIsCalledTwice()
        {
            Payment payment = new Payment()
            {
                Id = 1,
                Type = PaymentType.Book,
                Member = new MemberDetails()
                {
                    Address = "92 Imaginary Road",
                    Name = "John Doe"
                },
                Reference = "50 Shades of grey"
            };

            IPaymentRuleController controller = IoC.Container.GetService<IPaymentRuleController>();

            controller.RunPostPaymentLogic(payment);
            
            ///How can i assert this, my plan was to pass in a mock of the mapper and verify calls, but that feels more within the realm of unit tests.
        }
    }
}
