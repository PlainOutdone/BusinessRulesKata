using BusinessRulesKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesKata.Domain.PostPaymentProcess
{
    public interface IPostPaymentProcess
    {
        void Process( Payment payment);
    }
}
