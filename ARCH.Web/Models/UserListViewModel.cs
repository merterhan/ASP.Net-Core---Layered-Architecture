using System.Collections.Generic;
using ARCH.Web.Entities;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ARCH.Web.Models
{
    public class UserListViewModel : PagedListViewModel
    {
        public List<CustomIdentityUser> Users { get; set; }
        public ViewViewComponentResult Route { get; set; }
    }
}
