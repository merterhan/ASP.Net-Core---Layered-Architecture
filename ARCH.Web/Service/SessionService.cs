using ARCH.Web.Entities;
using ARCH.Web.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace ARCH.Web.Service
{
    public class SessionService : ISessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CustomIdentityUser GetUser()
        {
            return _httpContextAccessor.HttpContext.Session.GetObject<CustomIdentityUser>("user");
        }

        public void SetUser(CustomIdentityUser user)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("user", user);
        }
    }
}
