using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TenisProjesi.App_Class;

namespace TenisProjesi.Controllers
{
    public class Data{
        public List<User_Kiralama> user { get; set; }
        public List<Saat> saat { get; set; }
        public Data()
        {
            this.user =new List<User_Kiralama>();
            this.saat =new List<Saat>();


        }

    }
   
    public class HomeController : Controller
    {
        private TenisProjesiEntities db = new TenisProjesiEntities();
      

        public ActionResult Hakkimizda()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Iletisim()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UyeOl()
        {
            return View();
        }
        
        public ActionResult Index()
        {

            return View();
        }

        //Post..
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index(DateTime? date)
        {
            DateTime dt = DateTime.Now;
           /* if (date < dt)
                return View();*/
            if(date != null)
                return RedirectToAction("Kortlar",new {tarih= date });
            else
                return RedirectToAction("Kortlar");

        }
        [HttpGet]
        public ActionResult Kortlar(DateTime tarih)
        {

            List<Saat> saat1 = db.Saats.Where(m => m.tarih == tarih.Date).Where(m=>m.kortId==1).ToList();
            List<Saat> saat2 = db.Saats.Where(m => m.tarih == tarih.Date).Where(m=>m.kortId==2).ToList();
            Saat[] s1 = saat1.ToArray();
            Saat[] s2 = saat2.ToArray();

            ViewBag.saat1 = s1;
            ViewBag.saat2 = s2;
            return View();
        }

        public void SepeteEkle(int id)
        {
            Sepet.SepetUrun su = new Sepet.SepetUrun();

            Urunler u = db.Urunlers.Find(id);

            su.urun = u;
            su.Adet = 1;

            Sepet s = new Sepet();
            s.SepeteEkle(su);

        }
        public ActionResult Sepetim()
        {
            var urunler = db.Urunlers.ToList();
            if (HttpContext.Session["AktifSepet"] != null)
                return View((Sepet)HttpContext.Session["AktifSepet"]);
            else
                return View(urunler);

        }

        

        public ActionResult Kirala(int id)
        {
            Saat saatE = db.Saats.SingleOrDefault(m => m.Id == id);
            saatE.enable = false;

            User_Kiralama user_Kiralama =new User_Kiralama();
            if (!User.Identity.IsAuthenticated)
                user_Kiralama.userId = 3;
            else
                user_Kiralama.userId = User.Identity.GetUserId<int>();

            user_Kiralama.saatId = id;
            user_Kiralama.chekin = false;


            var submit = db.User_Kiralama.Add(user_Kiralama);

            db.SaveChanges();

            var u = db.User_Kiralama.OrderByDescending(m => m.Id).FirstOrDefault();

            if (User.Identity.IsAuthenticated)
                MailSender("mustafa.glr97@gmail.com", u.Id.ToString());

            return View("Urunler");
        }

        public ActionResult Chat()
        {
            if (User.Identity.IsAuthenticated)
                ViewBag.UserName = User.Identity.Name;
            else
                ViewBag.UserName = "Misafir";
            return View();
        }

        public ActionResult KortlarK()
        {
            return View();
        }
        public void dbEkle(int id)
        {
            Satislar satis = new Satislar();

            if (!User.Identity.IsAuthenticated)
                satis.userId = 3;
            else
                satis.userId = User.Identity.GetUserId<int>();

            satis.urunId = id;

            db.Satislars.Add(satis);
            db.SaveChanges();

          
            
        }
        
        public ActionResult Urunler()
        {
            return View();
        }

        public ActionResult Faturalandirma()
        {
           
            return View();
        }

        public ActionResult Faturalarim()
        {
            return View();
        }

        public ActionResult Aboneliklerim()
        {
            return View();
        }

        public ActionResult Takim()
        {
            return View();
        }

        private void MailSender(string address, string kiralamaId)// mail gönderme kısmı
        {
            
            var fromAddress = new MailAddress("tenisprj@gmail.com");
            var toAddress = new MailAddress(address);
            const string subject = "Site Adı | Sitenizden Gelen İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "tenisproje123")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = "http://localhost:58625/kontrols/Edit/" + kiralamaId
                })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}