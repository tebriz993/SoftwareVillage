using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using System.Net.Mail;
using System.Net;

namespace SoftwareVillage.Controllers
{
    public class MuracietController : Controller
    {
        private readonly SoftwareVillageDbContext _context;
        private readonly IConfiguration _configuration;

        public MuracietController(SoftwareVillageDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Muraciet> muraciet = _context.muracietler.ToList();
            return View(muraciet);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                ViewBag.Message = "Məlumat uğurla göndərildi!";
                return View();
            }
            return View(model);
        }

        private void SendEmail(ContactForm model)
        {
            var emailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>();

            var fromAddress = new MailAddress(emailSettings.FromEmail, "Your Name");
            var toAddress = new MailAddress(emailSettings.ToEmail, "Recipient Name");
            var fromPassword = emailSettings.SmtpPass;

            var smtp = new SmtpClient
            {
                Host = emailSettings.SmtpServer,
                Port = emailSettings.SmtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            string subject = "Yeni Müraciət";
            string body = $"Ad: {model.FirstName}\n" +
                          $"Soyad: {model.LastName}\n" +
                          $"Email: {model.Email}\n" +
                          $"Proqram: {model.Program}\n" +
                          $"Telefon: {model.PhonePrefix}-{model.PhoneNumber}";

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
    }
}
