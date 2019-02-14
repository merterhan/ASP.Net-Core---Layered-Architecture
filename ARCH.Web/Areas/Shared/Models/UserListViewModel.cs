using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Entities.Concrete;

namespace ARCH.Web.Areas.Shared.Models
{
    public class UserListViewModel
    {
        public List<User> User { get; internal set; }
    }
}
