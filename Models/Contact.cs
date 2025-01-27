using System;
using System.Collections.Generic;

namespace APISandbox__Blanca_Segura.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;
}
