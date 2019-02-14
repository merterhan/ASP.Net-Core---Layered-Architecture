using System;
using System.Collections.Generic;
using System.Text;
using ARCH.Business.Abstract;
using ARCH.DataAccess.Abstract;
using ARCH.Entities.Concrete;

namespace ARCH.Business.Concrete
{
    public class UserManager : IUserService
    {
        //dependency injection
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        //end dependency injection

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
