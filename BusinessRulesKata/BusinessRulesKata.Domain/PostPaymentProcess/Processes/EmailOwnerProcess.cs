using System;
using System.Collections.Generic;
using System.Text;
using BusinessRulesKata.Domain.BusinessLogicMapper;
using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.PostPaymentProcess.Processes
{
    public class EmailOwnerProcess : IPostPaymentProcess
    {
        private IBusinessLogicMapper _mapper;
        public EmailOwnerProcess(IBusinessLogicMapper mapper)
        {
            _mapper = mapper;
        }

        public void Process(Payment payment)
        {
            _mapper.SendEmailToOwner(new DummyEmail()
            {
                Subject = $"Membership status changed for member {payment.Member.Name}",
                ToAddress = "chief@obsuredrequirement.co.uk",
                Content = $"New membership payment has been recieved with a type of : {payment.Type.ToString()}"
            });
        }

    }
}
