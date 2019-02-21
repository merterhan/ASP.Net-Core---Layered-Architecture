using ARCH.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ARCH.Entities.Concrete
{
    public class Department : IEntity
    {
        [Key] public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public Guid? ChangedBy { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; }
        [ForeignKey("CustomIdentityUser")]
        public Guid? ManagerId { get; set; }
        [Column(TypeName = "VARCHAR(13)")]
        public string Phone { get; set; }
    }
}
