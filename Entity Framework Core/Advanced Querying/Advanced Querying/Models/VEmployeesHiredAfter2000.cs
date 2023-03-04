using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Introduction.Models;

[Keyless]
public partial class VEmployeesHiredAfter2000
{
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;
}