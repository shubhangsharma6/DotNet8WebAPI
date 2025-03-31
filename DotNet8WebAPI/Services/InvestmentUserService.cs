using DotNet8WebAPI.Entity;
using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNet8WebAPI.Services
{
    public class InvestmentUserService : IInvestmentUserService
    {
        public readonly AppSettings _appSettings;
        private readonly AdvisorDbContext _advisorDbContext;

        public InvestmentUserService(IOptions<AppSettings> appSettings, AdvisorDbContext advisorDbContext)
        {
                _appSettings = appSettings.Value;
                _advisorDbContext = advisorDbContext;
        }
        public Task<InvestmentUser?> AddUpdateInvestmentUser(InvestmentUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _advisorDbContext.InvestmentUser.SingleOrDefaultAsync(x=>x.Username == request.Username && x.Password == request.Password);
            if (user == null) { return null!; }
            var token = await GenerateJwTToken(user);
            return new AuthenticateResponse(user, token);

        }

        public Task<IEnumerable<InvestmentUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<InvestmentUser?> GetById(int id)
        {
            return await _advisorDbContext.InvestmentUser.FirstOrDefaultAsync(x=>x.Id == id);
        }

        private async Task<string> GenerateJwTToken(InvestmentUser investmentUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", investmentUser.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
