using System;
using System.Collections.Generic;
using System.Text;
using BusinessRulesKata.Domain.BusinessLogicMapper;
using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.PostPaymentProcess.Processes
{
    public class GeneratePackingSlipProcess : IPostPaymentProcess
    {
        private IBusinessLogicMapper _mapper;
        public GeneratePackingSlipProcess(IBusinessLogicMapper mapper)
        {
            _mapper = mapper;
        }

        public void Process(Payment payment)
        {
            _mapper.DoSomethingWithGeneratedPackingSlip(new PackingSlip()
            {
                RecipientName = payment.Member.Name,
                Address = payment.Member.Address,
                ReturnAddress = "ObsuredRequirement Ltd, 16 Snoozetown Road, Blahville"
            });
        }
    }
}
