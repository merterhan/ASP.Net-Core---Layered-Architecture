using ARCH.Core.DataAccess;
using ARCH.Entities.Concrete;

namespace ARCH.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        //custom operation like call stored procedure, or views, or join queries
    }
}
