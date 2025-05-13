public class Urun
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public string Kategori { get; set; }
    public decimal Fiyat { get; set; }

    public Urun(int id, string isim, string kategori, decimal fiyat)
    {
        Id = id;
        Isim = isim;
        Kategori = kategori;
        Fiyat = fiyat;
    }

    public override string ToString()
    {
        return $"{Id}: {Isim} - {Kategori} - {Fiyat} ₺";
    }
}