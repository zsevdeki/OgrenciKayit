using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayit
{
   public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad boş olmaz"), DisplayName("Adı")]//boş bırakılmamsını sağlıyor.
        public string Ad { get; set; }
        public string Soyad { get; set; }       
        public int Tc { get; set; }
        [StringLength(11)]
        public string Mail { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Yas { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int SinifId { get; set; }

        public override string ToString()
        {
            return Ad + " " + Soyad + " " + Tc + " " + Mail+" "+Yas;
        }
        public virtual Sinif sinif { get; set; }
    }
}
