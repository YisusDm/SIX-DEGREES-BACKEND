using System;
using System.Collections.Generic;

namespace SIX_DEGREES_BACKEND.Models;

public partial class Usuario
{
    public int UsuId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }
}
