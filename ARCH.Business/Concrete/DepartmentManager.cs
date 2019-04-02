using System;
using System.Collections.Generic;
using ARCH.Business.Abstract;
using ARCH.DataAccess.Abstract;
using ARCH.Entities.Concrete;

namespace ARCH.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        //dependency injection
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        //end dependency injection

        public List<Department> GetList()
        {
            var list = _departmentDal.GetListAsNoTracking();
            return list;
        }

        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        public void Delete(Guid id)
        {
            _departmentDal.Delete(new Department(){ Id = id});
        }

        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
