using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARCH.Core.Entities
{
    public interface IEntity
    {
        [Key]
        Guid Id { get; }
    }
}
