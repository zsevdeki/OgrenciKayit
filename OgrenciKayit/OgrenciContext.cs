using OgrenciKayit.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayit
{
    class OgrenciContext: DbContext
    {
        public OgrenciContext():base ("OgrenciContext")
        {
            //değişiklik yaptığımızda bir daha update databese falan yapmamıza gerek kalmadı.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OgrenciContext, Configuration>("OgrenciContext"));
            //Farklı bir şekilde CodFirst e yaptığımız değişiklikleri veri tabanına hata vermeyecek şekilde kodlamamızın 4 farklı stratejisi var
            // 1- CreateDatabaseIfNotExist--> bu model veri tabanında yoksa bir kerelik yaz, varsa hata verecektir.
            // 2 - DropCreatDatabaseIfModelChanges--> Her çalıştığında modeli kontrol eder ve değişiklik varsa veri tabanını silip yeniden oluşturur.
            // 3 - DropCreatDatabaseAlways --> Her çalıştığında veri tabanını silip yeniden oluşturur.
            // 4 - MigrateDatabaseToLatestVersion --> EF 6.0 versiyonundan itibaren kullanılıyor.Eğer nodel de  bir değişiklik olduysa veritabanını günceller.
        }
        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }
        public virtual DbSet<Sinif>Siniflar { get; set; }

        //Database de ogrecis i türkçe olarak yazdırmak için yapıldı.(ogrenci yazdı)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
