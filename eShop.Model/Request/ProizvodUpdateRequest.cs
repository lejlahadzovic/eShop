using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Models.Request
{
    public class ProizvodUpdateRequest
    {
        public string Naziv { get; set; } = null!;
        public decimal? Cijena { get; set; }
        public int? JedinicaMjereId { get; set; }
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb {get; set;}
    }
}
