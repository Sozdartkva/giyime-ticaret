using System;
using System.Collections.Generic;

class Program
{
    static List<Urun> urunler = new List<Urun>();
    static List<Kullanici> kullanicilar = new List<Kullanici>();
    static Kullanici aktifKullanici = null;
    static int urunSayaci = 3;

    static void Main()
    {
        IlkVerileriYukle();
        AnaMenu();
    }

    static void IlkVerileriYukle()
    {
        urunler.Add(new Urun(1, "Tişört", "Üst Giyim", 199.99m));
        urunler.Add(new Urun(2, "Kot Pantolon", "Alt Giyim", 349.99m));
        urunler.Add(new Urun(3, "Mont", "Dış Giyim", 599.99m));

        kullanicilar.Add(new Kullanici("admin", "1234", true));
    }

    static void AnaMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Giyim E-Ticaret Sitesi ---");
            Console.WriteLine("1. Kayıt Ol");
            Console.WriteLine("2. Giriş Yap");
            Console.WriteLine("3. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": KayitOl(); break;
                case "2": GirisYap(); break;
                case "3": return;
                default: Console.WriteLine("Geçersiz seçim."); break;
            }
        }
    }

    static void KayitOl()
    {
        Console.Write("Kullanıcı Adı: ");
        string ad = Console.ReadLine();
        Console.Write("Şifre: ");
        string sifre = Console.ReadLine();

        kullanicilar.Add(new Kullanici(ad, sifre));
        Console.WriteLine("Kayıt başarılı!");
    }

    static void GirisYap()
    {
        Console.Write("Kullanıcı Adı: ");
        string ad = Console.ReadLine();
        Console.Write("Şifre: ");
        string sifre = Console.ReadLine();

        foreach (var kullanici in kullanicilar)
        {
            if (kullanici.KullaniciAdi == ad && kullanici.Sifre == sifre)
            {
                aktifKullanici = kullanici;
                Console.WriteLine($"\nHoş geldiniz, {ad}!");
                if (kullanici.AdminMi)
                    AdminMenusu();
                else
                    KullaniciMenusu();
                return;
            }
        }

        Console.WriteLine("Giriş başarısız.");
    }

    static void KullaniciMenusu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Kullanıcı Paneli ---");
            Console.WriteLine("1. Ürünleri Listele");
            Console.WriteLine("2. Sepete Ürün Ekle");
            Console.WriteLine("3. Sepeti Görüntüle");
            Console.WriteLine("4. Siparişi Tamamla");
            Console.WriteLine("5. Çıkış Yap");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": UrunleriListele(); break;
                case "2": SepeteUrunEkle(); break;
                case "3": aktifKullanici.SepetiGoster(); break;
                case "4": aktifKullanici.SiparisiTamamla(); break;
                case "5": aktifKullanici = null; return;
                default: Console.WriteLine("Geçersiz seçim."); break;
            }
        }
    }

    static void AdminMenusu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Admin Paneli ---");
            Console.WriteLine("1. Ürünleri Listele");
            Console.WriteLine("2. Yeni Ürün Ekle");
            Console.WriteLine("3. Ürün Sil");
            Console.WriteLine("4. Çıkış Yap");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": UrunleriListele(); break;
                case "2": UrunEkle(); break;
                case "3": UrunSil(); break;
                case "4": aktifKullanici = null; return;
                default: Console.WriteLine("Geçersiz seçim."); break;
            }
        }
    }

    static void UrunleriListele()
    {
        Console.WriteLine("\n--- Ürün Listesi ---");
        foreach (var urun in urunler)
        {
            Console.WriteLine(urun);
        }
    }

    static void SepeteUrunEkle()
    {
        UrunleriListele();
        Console.Write("Sepete eklemek istediğiniz ürün ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Urun secilen = urunler.Find(u => u.Id == id);
            if (secilen != null)
            {
                aktifKullanici.SepeteEkle(secilen);
                Console.WriteLine("Ürün sepete eklendi.");
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz giriş.");
        }
    }

    static void UrunEkle()
    {
        urunSayaci++;
        Console.Write("Ürün Adı: ");
        string isim = Console.ReadLine();
        Console.Write("Kategori: ");
        string kategori = Console.ReadLine();
        Console.Write("Fiyat: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal fiyat))
        {
            urunler.Add(new Urun(urunSayaci, isim, kategori, fiyat));
            Console.WriteLine("Ürün başarıyla eklendi.");
        }
        else
        {
            Console.WriteLine("Geçersiz fiyat girdisi.");
        }
    }

    static void UrunSil()
    {
        UrunleriListele();
        Console.Write("Silmek istediğiniz ürün ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Urun secilen = urunler.Find(u => u.Id == id);
            if (secilen != null)
            {
                urunler.Remove(secilen);
                Console.WriteLine("Ürün silindi.");
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz giriş.");
        }
    }
}