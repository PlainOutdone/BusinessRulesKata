using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesKata.Models
{
    public class Payment
    {
        public int Id;
        public PaymentType Type;
        public string Reference;
        public DateTime DateRequested;
        public MemberDetails Member;
    }
}
