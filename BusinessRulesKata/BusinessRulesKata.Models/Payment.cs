using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesKata.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentType Type { get; set; }
        public string Reference { get; set; }
    }
}