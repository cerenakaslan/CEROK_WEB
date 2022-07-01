using CEROK_WEBAPP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEROK_WEBAPP.Models
{
    public class HastaModel
    {
        public int hastaID { get; set; }
        public string tc { get; set; } = null!;
        public string sifre { get; set; } = null!;
        public string isim { get; set; } = null!;
        public string soyad { get; set; } = null!;
        public string cinsiyet { get; set; } = null!;
        public DateTime dogumTarihi { get; set; }
        public string telefonNo { get; set; } = null!;
        public string? email { get; set; }
        public string? kanGrubu { get; set; }
        public int? yas { get; set; }
        public int? boy { get; set; }
        public int? kilo { get; set; }



    }
}
