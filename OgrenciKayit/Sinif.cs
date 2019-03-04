using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayit
{
    public class Sinif
    {
        [Key]
        public int SinifId { get; set; }
        [StringLength(50)]
        public string Aciklama { get; set; }

        public virtual ICollection<Ogrenci> ogrenciler { get; set; }
    }
}
