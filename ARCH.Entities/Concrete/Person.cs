using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ARCH.Core.Entities;

namespace ARCH.Entities.Concrete
{
    public class Person : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public Guid? ChangedBy { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Gender { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string TCKN { get; set; }
        public virtual Department Department { get; set; }
        
    }
}
