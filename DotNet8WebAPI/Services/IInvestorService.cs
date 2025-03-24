using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Services
{
    public interface IInvestorService
    {
        List<Investor> GetAllInvestors(bool isActive);
        Investor GetInvestorsById(int id);
        Investor AddInvestor(AddUpdateInvestor investor);
        Investor? UpdateInvestor(int id, AddUpdateInvestor investor);
        bool DeleteInvestor(int id);
    }
}
