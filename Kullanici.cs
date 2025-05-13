using System;
using System.Collections.Generic;

public class Kullanici
{
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public bool AdminMi { get; set; }
    public List<Urun> Sepet { get; set; }

    public Kullanici(string kullaniciAdi, string sifre, bool adminMi = false)
    {
        KullaniciAdi = kullaniciAdi;
        Sifre = sifre;
        AdminMi = adminMi;
        Sepet = new List<Urun>();
    }

    public void SepeteEkle(Urun urun)
    {
        Sepet.Add(urun);
    }

    public void SepetiGoster()
    {
        Console.WriteLine("\n--- Sepetiniz ---");
        if (Sepet.Count == 0)
        {
            Console.WriteLine("Sepetiniz boş.");
            return;
        }

        foreach (var urun in Sepet)
        {
            Console.WriteLine(urun);
        }

        decimal toplam = 0;
        foreach (var urun in Sepet)
        {
            toplam += urun.Fiyat;
        }
        Console.WriteLine($"Toplam Tutar: {toplam} ₺");
    }

    public void SiparisiTamamla()
    {
        if (Sepet.Count == 0)
        {
            Console.WriteLine("Sepetiniz boş. Sipariş verilemez.");
            return;
        }

        Console.WriteLine("\nSiparişiniz başarıyla oluşturuldu. Sipariş özeti:");
        SepetiGoster();
        Sepet.Clear();
    }
}