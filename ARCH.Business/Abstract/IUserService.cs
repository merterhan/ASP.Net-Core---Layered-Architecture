using ARCH.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARCH.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int user);
    }
}
