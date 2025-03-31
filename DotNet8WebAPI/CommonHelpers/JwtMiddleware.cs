using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DotNet8WebAPI.CommonHelpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
                _next = next;
                _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IInvestmentUserService investmentUserService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null) 
            { 
                await AttachUserToContext(context, investmentUserService, token);
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IInvestmentUserService investmentUserService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                context.Items["InvestmentUser"] = await investmentUserService.GetById(userId);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            
        }
    }
}
