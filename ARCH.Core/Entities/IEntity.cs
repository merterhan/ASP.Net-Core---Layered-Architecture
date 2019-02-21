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
        DateTime CreatedOn { get; set; }
        DateTime? ChangedOn { get; set; }
        string CreatedBy { get; set; }
        Guid? ChangedBy { get; set; }
    }
}
