using System;
using System.Collections.Generic;

namespace ToDoApp.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Naslov { get; set; } = null!;

    public string? Opis { get; set; }

    public DateTime DatumUstvarjanja { get; set; }

    public bool Opravljeno { get; set; }
}
