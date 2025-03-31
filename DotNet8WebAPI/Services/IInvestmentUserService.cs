using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Services
{
    public interface IInvestmentUserService
    {
        Task <AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<InvestmentUser>> GetAll();
        Task<InvestmentUser?> GetById(int id);
        Task<InvestmentUser?> AddUpdateInvestmentUser(InvestmentUser user);
    }
}
