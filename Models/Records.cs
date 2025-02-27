using System;

namespace cozum8.Models
{
    public class UretimKaydi
    {
        public int KayitNo { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public TimeSpan ToplamSure { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? DurusNedeni { get; set; }
    }

    public class StandartDurus
    {
        public TimeSpan Baslangic { get; set; }
        public TimeSpan Bitis { get; set; }
        public string DurusNedeni { get; set; }
    }

    public class UretimOperasyon
    {
        public int KayitNo { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public TimeSpan ToplamSure { get; set; }
        public string Status { get; set; }
        public string? DurusNedeni { get; set; }
    }

    public class ServiceRecord
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
