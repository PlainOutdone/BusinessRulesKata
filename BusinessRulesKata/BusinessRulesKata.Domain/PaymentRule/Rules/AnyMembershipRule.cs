﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.PaymentRule.Rules
{
    public class AnyMembershipRule : IPaymentRule
    {
        public bool IsValid(Payment payment)
        {
            return (payment.Type == PaymentType.Membership || payment.Type == PaymentType.MembershipUpgrade);
        }
    }
}
