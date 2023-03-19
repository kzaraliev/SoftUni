using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XML_Processing.Models;

public partial class Project
{
    public Project()
    {
        Employees = new HashSet<Employee>();
    }

    [Key]
    [Column("ProjectID")]
    public int ProjectId { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime? EndDate { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty(nameof(Employee.Projects))]
    public virtual ICollection<Employee> Employees { get; set; }
}