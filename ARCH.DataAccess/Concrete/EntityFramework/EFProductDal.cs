﻿using ARCH.Core.DataAccess.EntityFrameworkCore;
using ARCH.DataAccess.Abstract;
using ARCH.Entities.Concrete;

namespace ARCH.DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFRepository<User, ARCHContext>, IUserDal
    {
    }
}
