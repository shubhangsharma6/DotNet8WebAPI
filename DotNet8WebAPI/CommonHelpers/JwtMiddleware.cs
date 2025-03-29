using DotNet8WebAPI.Model;
using Microsoft.Extensions.Options;

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
    }
}
