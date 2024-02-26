using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Models.Request
{
    public class ProizvodInsertRequest
    {
        public string Naziv { get; set; } = null!;
        public string Sifra { get; set; } = null!;
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }
    }
}
