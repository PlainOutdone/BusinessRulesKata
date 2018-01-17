using BusinessRulesKata.Models;

namespace BusinessRulesKata.Domain.BusinessLogicMapper
{
    public interface IBusinessLogicMapper
    {
        void GenerateMembership(MemberDetails member);
        void UpdateMembership(MemberDetails member);
        void SendEmailToOwner(DummyEmail email);
        void DoSomethingWithGeneratedPackingSlip(PackingSlip packingSlip);
    }
}
