using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Services
{
    public class InvestorService : IInvestorService
    {
        private readonly List<Investor> _investorList;

        public InvestorService()
        {
            _investorList = new List<Investor>()
            {
                new Investor()
                {
                    Id = 1,
                    FirstName = "Prince",
                    LastName = "Kumar",
                    isActive = true
                },
                new Investor()
                {
                    Id = 2,
                    FirstName = "Bhajan",
                    LastName = "Pratap",
                    isActive= true
                },
                new Investor()
                {
                    Id = 3,
                    FirstName = "Sherry",
                    LastName = "Falkner",
                    isActive = false
                }
            };
        }

        public Investor AddInvestor(AddUpdateInvestor investor)
        {
            var newInvestor = new Investor()
            {
                Id = _investorList.Max(x => x.Id) + 1,
                FirstName = investor.FirstName,
                LastName= investor.LastName,
                isActive = investor.isActive
            };

            _investorList.Add(newInvestor);

            return newInvestor;
        }

        public bool DeleteInvestor(int id)
        {
            var investorIndex = _investorList.FindIndex(x => x.Id == id);

            if(investorIndex >= 0)
            {
                _investorList.RemoveAt(investorIndex);
            }

            return investorIndex >= 0;
        }

        public List<Investor> GetAllInvestors(bool isActive)
        {
            return _investorList.Where(x=>x.isActive == isActive).ToList();
        }

        public Investor GetInvestorsById(int id)
        {
            return _investorList.FirstOrDefault(x => x.Id == id)!;
        }

        public Investor? UpdateInvestor(int id, AddUpdateInvestor investor)
        {
            var investorIndex = _investorList.FindIndex(x => x.Id == id);
            if(investorIndex > 0)
            {
                var inv = _investorList[investorIndex];
                inv.FirstName = investor.FirstName;
                inv.LastName = investor.LastName;
                inv.isActive = investor.isActive;
                _investorList[investorIndex] = inv;

                return inv;
            }

            else
            {
                return null;
            }            
        }
    }
}
