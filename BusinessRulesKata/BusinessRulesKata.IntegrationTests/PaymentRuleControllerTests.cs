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
        public static void WhenProvidedAPaymentForABookEnsureThePackingSlipProcessIsCalledOnceAndGenerateCommisionOnce()
        {
            Mock < IBusinessLogicMapper > mapper = new Mock<IBusinessLogicMapper>();
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

            controller.RunPostPaymentLogic(payment, mapper.Object);
            mapper.Verify(m => m.DoSomethingWithGeneratedPackingSlip(It.IsAny<PackingSlip>()),Times.Once);
        }
    }
}
