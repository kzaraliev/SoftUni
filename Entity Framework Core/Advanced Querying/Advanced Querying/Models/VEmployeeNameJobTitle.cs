using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Introduction.Models;

[Keyless]
public partial class VEmployeeNameJobTitle
{
    [Column("Full Name")]
    [StringLength(152)]
    [Unicode(false)]
    public string FullName { get; set; } = null!;
    [StringLength(50)]
    [Unicode(false)]
    public string JobTitle { get; set; } = null!;
}