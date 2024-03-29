﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Proizvod
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Sifra { get; set; } = null!;
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }
        public bool? Status { get; set; }
        public string? StateMachine { get; set; }
    }
}
