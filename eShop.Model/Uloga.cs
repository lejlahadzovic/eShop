﻿using System;
using System.Collections.Generic;

namespace eShop.Models;

public partial class Uloga
{
    public int UlogaId { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Opis { get; set; }
}
