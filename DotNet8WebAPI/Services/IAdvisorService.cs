using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Services
{
    public interface IAdvisorService
    {
        Task<List<Advisor>> GetAllAdvisors(bool isActive);
        Task<Advisor> GetAdvisorById(int id);
        Task<Advisor>? AddAdvisor(AddUpdateAdvisor advisor);
        Task<Advisor>? UpdateAdvisor(int id, AddUpdateAdvisor advisor);
        Task<bool>? DeleteAdvisor(int id);
    }
}
