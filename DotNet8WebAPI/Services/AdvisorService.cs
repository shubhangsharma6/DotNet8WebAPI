using DotNet8WebAPI.Entity;
using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPI.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly AdvisorDbContext _advisorDbContext;

        public AdvisorService(AdvisorDbContext advisorDbContext)
        {
            _advisorDbContext = advisorDbContext;
        }

        public async Task<Advisor>? AddAdvisor(AddUpdateAdvisor advisor)
        {
            var addAdvisor = new Advisor
            {
                FirstName = advisor.FirstName,
                LastName = advisor.LastName,
                IsActive = advisor.isActive
            };
            _advisorDbContext.Advisors.Add(addAdvisor);
            var result = await _advisorDbContext.SaveChangesAsync();
            if (result >= 0)
            {
                return addAdvisor!;
            }
            else
            {
                return null!;
            }
        }

        public async Task<bool> DeleteAdvisor(int id)
        {
            var removeAdvisor = await _advisorDbContext.Advisors.FirstOrDefaultAsync(x => x.Id == id);
            if (removeAdvisor != null)
            {
                _advisorDbContext.Remove(removeAdvisor);
                var result = await _advisorDbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

        public async Task<Advisor> GetAdvisorById(int id)
        {
            var advisor = await _advisorDbContext.Advisors.FirstOrDefaultAsync(x => x.Id == id);
            return advisor!;
        }

        public async Task<List<Advisor>> GetAllAdvisors(bool isActive)
        {
            return await _advisorDbContext.Advisors.Where(a => a.IsActive == isActive).ToListAsync();
        }

        public async Task<Advisor>? UpdateAdvisor(int id, AddUpdateAdvisor advisor)
        {
            var updateAdvisor = await _advisorDbContext.Advisors.FirstOrDefaultAsync(x => x.Id == id);
            if (updateAdvisor != null)
            {
                updateAdvisor.FirstName = advisor.FirstName;
                updateAdvisor.LastName = advisor.LastName;
                updateAdvisor.IsActive = advisor.isActive;

                var result = await _advisorDbContext.SaveChangesAsync();
                if (result >= 0)
                {
                    return updateAdvisor!;
                }
                else
                {
                    return null!;
                }
            }

            return null!;

        }
    }
}
