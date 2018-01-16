using BusinessRulesKata.Domain.PaymentRule;
using BusinessRulesKata.Domain.PaymentRule.Rules;
using BusinessRulesKata.Models;
using System;
using System.Text;
using Xunit;

namespace BusinessRulesKata.UnitTests.PaymentRule
{
    public partial class PaymentRuleTests
    {
        [Fact]
        public static void ValidateBookRule()
        {
            Payment payment = new Payment() { Type = PaymentType.Book };
            PaymentRuleTestBuilder builder = new PaymentRuleTestBuilder();

            builder.AddPassingRule(typeof(PhysicalProductOrBookRule))
                   .AddPassingRule(typeof(BookRule));

            PaymentRuleValidator validator = new PaymentRuleValidator();
            validator.ValidateAllRules(payment, builder);
        }

        [Fact]
        public static void ValidateMembershipActivationPayment()
        {
            Payment payment = new Payment() { Type = PaymentType.Membership };
            PaymentRuleTestBuilder builder = new PaymentRuleTestBuilder();

            builder.AddPassingRule(typeof(MembershipActivationRule))
                   .AddPassingRule(typeof(AnyMembershipRule));

            PaymentRuleValidator validator = new PaymentRuleValidator();
            validator.ValidateAllRules(payment, builder);
        }

        [Fact]
        public static void ValidateMembershipUpgrade()
        {
            Payment payment = new Payment() { Type = PaymentType.MembershipUpgrade };
            PaymentRuleTestBuilder builder = new PaymentRuleTestBuilder();

            builder.AddPassingRule(typeof(MembershipUpgradeRule))
                   .AddPassingRule(typeof(AnyMembershipRule));

            PaymentRuleValidator validator = new PaymentRuleValidator();
            validator.ValidateAllRules(payment, builder);
        }

        [Fact]
        public static void ValidateVideoRule()
        {
            Payment payment = new Payment() { Type = PaymentType.Video };
            PaymentRuleTestBuilder builder = new PaymentRuleTestBuilder();

            builder.AddPassingRule(typeof(VideoRule));

            PaymentRuleValidator validator = new PaymentRuleValidator();
            validator.ValidateAllRules(payment, builder);
        }

        [Fact]
        public static void ValidateLearningToSkiVideoRule()
        {
            Payment payment = new Payment() { Type = PaymentType.Video, Reference="Learning to Ski", DateRequested = new DateTime(2017,01,01)};
            PaymentRuleTestBuilder builder = new PaymentRuleTestBuilder();

            builder.AddPassingRule(typeof(VideoRule))
                .AddPassingRule(typeof(LearningToSkiRule));

            PaymentRuleValidator validator = new PaymentRuleValidator();
            validator.ValidateAllRules(payment, builder);
        }

        [Fact]
        public static void ValidatePhysicalProductRule()
        {
            Payment payment = new Payment() { Type = PaymentType.PhysicalProduct };
            PaymentRuleTestBuilder builder = new PaymentRuleTestBuilder();

            builder.AddPassingRule(typeof(PhysicalProductOrBookRule))
                   .AddPassingRule(typeof(PhysicalProductRule));

            PaymentRuleValidator validator = new PaymentRuleValidator();
            validator.ValidateAllRules(payment, builder);
        }

    }
}
