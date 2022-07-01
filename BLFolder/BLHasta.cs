using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace CEROK_WEBAPP.BLFolder
{
    public class BLHasta
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


        public async Task<bool> BLHastaLogin(int id, string hastaSifresi)
        {
            HttpClient hasta = new HttpClient();
            hasta.BaseAddress = new Uri("https://localhost:7086/");


            hasta.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //Headera paramtereleri ekle

            using (HttpClient httpClient = new HttpClient() { BaseAddress = hasta.BaseAddress })
            {
                HttpResponseMessage request = await hasta.GetAsync($"api/Hasta/{id}");
                var content = await request.Content.ReadAsStringAsync();
                BLHasta blhasta = JsonConvert.DeserializeObject<BLHasta>(content);

                if (blhasta != null && blhasta.hastaID != 0)
                {

                    if (blhasta.hastaID == id && blhasta.sifre== hastaSifresi)
                    {

                        //Session.Add("aktif", "HastaID");
                        //return RedirectToAction("LoginView", "Account");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    // ViewBag.Mesaj = "Lütfen kayıt olunuz";
                    // return View();
                    return false;
                }
            }
        }
    }
}
