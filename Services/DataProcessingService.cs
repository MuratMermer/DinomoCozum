using System;
using System.Collections.Generic;
using System.Linq;
using cozum8.Models;

namespace cozum8.Services
{
    public class DataProcessingService
    {
        public List<UretimKaydi> UretimVerileri { get; set; }
        public List<StandartDurus> StandartDuruslar { get; set; }

        public DataProcessingService()
        {
            UretimVerileri = new List<UretimKaydi>
            {
                new UretimKaydi { KayitNo = 1, Baslangic = DateTime.Parse("2020-05-23 07:30"), Bitis = DateTime.Parse("2020-05-23 08:30"), ToplamSure = TimeSpan.FromHours(1), Status = "URETIM", DurusNedeni = null },
                new UretimKaydi { KayitNo = 2, Baslangic = DateTime.Parse("2020-05-23 08:30"), Bitis = DateTime.Parse("2020-05-23 12:00"), ToplamSure = TimeSpan.FromHours(3.5), Status = "URETIM", DurusNedeni = null },
                new UretimKaydi { KayitNo = 3, Baslangic = DateTime.Parse("2020-05-23 12:00"), Bitis = DateTime.Parse("2020-05-23 13:00"), ToplamSure = TimeSpan.FromHours(1), Status = "URETIM", DurusNedeni = null },
                new UretimKaydi { KayitNo = 4, Baslangic = DateTime.Parse("2020-05-23 13:00"), Bitis = DateTime.Parse("2020-05-23 13:45"), ToplamSure = TimeSpan.FromMinutes(45), Status = "DURUŞ", DurusNedeni = "ARIZA" },
                new UretimKaydi { KayitNo = 5, Baslangic = DateTime.Parse("2020-05-23 13:45"), Bitis = DateTime.Parse("2020-05-23 17:30"), ToplamSure = TimeSpan.FromHours(3.75), Status = "URETIM", DurusNedeni = null }
            };

            StandartDuruslar = new List<StandartDurus>
            {
                new StandartDurus { Baslangic = TimeSpan.Parse("10:00"), Bitis = TimeSpan.Parse("10:15"), DurusNedeni = "Çay Molası" },
                new StandartDurus { Baslangic = TimeSpan.Parse("12:00"), Bitis = TimeSpan.Parse("12:30"), DurusNedeni = "Yemek Molası" },
                new StandartDurus { Baslangic = TimeSpan.Parse("15:00"), Bitis = TimeSpan.Parse("15:15"), DurusNedeni = "Çay Molası" },
                new StandartDurus { Baslangic = TimeSpan.Parse("19:00"), Bitis = TimeSpan.Parse("19:30"), DurusNedeni = "Yemek Molası" }
            };
        }

        public List<UretimOperasyon> GetUretimOperasyonlari()
        {
            var operasyonlar = new List<UretimOperasyon>();

            foreach (var uretim in UretimVerileri)
            {
                DateTime startTime = uretim.Baslangic;
                DateTime endTime = uretim.Bitis;

                foreach (var durus in StandartDuruslar)
                {
                    DateTime durusBaslangic = uretim.Baslangic.Date + durus.Baslangic;
                    DateTime durusBitis = uretim.Baslangic.Date + durus.Bitis;

                    if (startTime <= durusBaslangic && durusBaslangic < endTime)
                    {
                        if (startTime < durusBaslangic)
                        {
                            operasyonlar.Add(new UretimOperasyon { KayitNo = uretim.KayitNo, Baslangic = startTime, Bitis = durusBaslangic, ToplamSure = durusBaslangic - startTime, Status = "URETIM", DurusNedeni = null });
                        }

                        operasyonlar.Add(new UretimOperasyon { KayitNo = uretim.KayitNo, Baslangic = durusBaslangic, Bitis = durusBitis, ToplamSure = durusBitis - durusBaslangic, Status = "DURUŞ", DurusNedeni = durus.DurusNedeni });

                        startTime = durusBitis;
                    }
                }

                if (startTime < endTime)
                {
                    operasyonlar.Add(new UretimOperasyon { KayitNo = uretim.KayitNo, Baslangic = startTime, Bitis = endTime, ToplamSure = endTime - startTime, Status = uretim.Status, DurusNedeni = uretim.DurusNedeni });
                }
            }

            return operasyonlar;
        }

        public IEnumerable<UretimKaydi> GetAllServices()
        {
            // Var olan üretim verilerini döndür
            return UretimVerileri;
        }
    }
}
