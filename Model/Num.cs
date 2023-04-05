using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRPO1.Entities;

public partial class Num
{
    public double? FirstNumber { get; set; }

    public int? FirstNumberNotation { get; set; }

    public double? SecondNumber { get; set; }

    public int? SecondNumberNotation { get; set; }

    public string? Operation { get; set; }
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id { get; set; }
}
