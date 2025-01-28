using System;
using System.Collections.Generic;

namespace APISandbox__Blanca_Segura.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string? Description { get; set; }
}
