using ARCH.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ARCH.Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        void Add(Department department);
        void Update(Department department);
        void Delete(Guid id);
    }
}
