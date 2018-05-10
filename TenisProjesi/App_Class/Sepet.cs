using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenisProjesi.App_Class
{
    public class Sepet
    {
        //Sepet tipinde "AktifSepet" adında bir propery
        public static Sepet AktifSepet
        {
            get
            {
                //ziyaretçinin oturum nesnelerini "ctx" değişkeninde tut
                HttpContext ctx = HttpContext.Current;

                //eğer sepet yok ise sepet oluştur
                if (ctx.Session["AktifSepet"] == null)
                    ctx.Session["AktifSepet"] = new Sepet();

                //sepeti döndür
                return (Sepet)ctx.Session["AktifSepet"];
            }
        }

        public class SepetUrun //sepetteki satırların tutulduğu sınıf
        {

            public Urunler urun { get; set; }
            public int Adet { get; set; }
            public decimal Tutar
            {
                get
                {
                    return Adet * decimal.Parse(urun.urunFiyat);
                }
            }
        }

        //sepette bulunan ürünlerin listesi
        private List<SepetUrun> urunler = new List<SepetUrun>();

        //listedeki ürünler "Urunler" özelliği ile çekilecek
        public List<SepetUrun> Urunler
        {
            get { return urunler; }
            set { urunler = value; }
        }

        //ürünlerin sepete eklenmesini sağlayan metot
        public void SepeteEkle(SepetUrun su)
        {
            //oturum değişkenlerinde AktifSepet boşsa
            if (HttpContext.Current.Session["AktifSepet"] == null)
            {
                //yeni sepet oluştur
                Sepet sepet = new Sepet();
                //Ürünü sepete ekle
                sepet.Urunler.Add(su);
                //sepeti "AktifSepet"e ekle
                HttpContext.Current.Session["AktifSepet"] = sepet;
            }
            else//AktifSepet doluysa
            {
                //AktifSepet adlı oturum değişkenini sepet nesnesine ata
                Sepet sepet = (Sepet)HttpContext.Current.Session["AktifSepet"];
                //eğer sepette aynı ürün varsa ürün adetini artır
                if (sepet.Urunler.Any(x => x.urun.Id == su.urun.Id))
                    Urunler.FirstOrDefault(x => x.urun.Id == su.urun.Id).Adet += 1;
                else//aynı ürün yoksa ürünü sepete ekle
                    sepet.Urunler.Add(su);
            }
        }

        public decimal GenelToplam
        {
            //sepetteki ürünlerin toplam fiyatı
            get { return Urunler.Sum(x => x.Tutar); }
        }

    }
}