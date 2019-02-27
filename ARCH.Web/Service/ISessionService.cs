using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Web.Entities;
using Microsoft.AspNetCore.Identity;

namespace ARCH.Web.Service
{
    public interface ISessionService
    {
        CustomIdentityUser GetUser();
        void SetUser(CustomIdentityUser user);
    }
}
