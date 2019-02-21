using ARCH.Core.DataAccess;
using ARCH.Entities.Concrete;

namespace ARCH.DataAccess.Abstract
{
    public interface IDepartmentDal : IRepository<Department>
    {
        //custom operation like call stored procedure, or views, or join queries
    }
}
