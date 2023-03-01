using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LINQ.Models
{
    public partial class Address
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string AddressText { get; set; } = null!;
        [Column("TownID")]
        public int? TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        [InverseProperty("Addresses")]
        public virtual Town? Town { get; set; }
        [InverseProperty(nameof(Employee.Address))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
