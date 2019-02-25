using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARCH.Business.Abstract;
using ARCH.DataAccess.Abstract;
using ARCH.Entities.Concrete;

namespace ARCH.Business.Concrete
{
    public class DepartmantManager : IDepartmentService
    {
        //dependency injection
        private IDepartmentDal _departmentDal;

        public DepartmantManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        //end dependency injection

        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        public void Delete(Guid id)
        {
            _departmentDal.Delete(new Department(){ Id = id});
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll().ToList();
        }

        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
