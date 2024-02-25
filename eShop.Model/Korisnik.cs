using System;
using System.Collections.Generic;

namespace eShop.Models
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public bool? Status { get; set; }
    }
}

