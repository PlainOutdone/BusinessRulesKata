using BusinessRulesKata.Domain.BusinessLogicMapper;
using BusinessRulesKata.Domain.PostPaymentProcess;
using BusinessRulesKata.Domain.PostPaymentProcess.Processes;
using BusinessRulesKata.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BusinessRulesKata.UnitTests
{
    public class PostPaymentProcessTests
    {
        [Fact]
        public static void WhenIInvokeTheEmailOwnerProcessEnsureTheMapperIsCalled()
        {
            Mock<IBusinessLogicMapper> mapper = new Mock<IBusinessLogicMapper>();   
            IPostPaymentProcess process = new EmailOwnerProcess(mapper.Object);

            process.Process(new Payment() {Member = new MemberDetails() });

            mapper.Verify(m => m.SendEmailToOwner(It.IsAny<DummyEmail>()));
        }

        [Fact]
        public static void WhenIInvokeTheGeneratePackingSlipProcessensureTheMapperIsCalled()
        {
            Mock<IBusinessLogicMapper> mapper = new Mock<IBusinessLogicMapper>();
            IPostPaymentProcess process = new GeneratePackingSlipProcess(mapper.Object);

            process.Process(new Payment() { Member = new MemberDetails() });

            mapper.Verify(m => m.DoSomethingWithGeneratedPackingSlip(It.IsAny<PackingSlip>()));
        }
    }
}
