using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Models.Request
{
    public class ProizvodInsertRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; } = null!;
        [Required(AllowEmptyStrings =false, ErrorMessage = "Sifra je obavezna")]
        [MinLength(1)]
        [MaxLength(10)]
        public string Sifra { get; set; } = null!;
        [Required]
        [Range(0,10000)]
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }
    }
}
