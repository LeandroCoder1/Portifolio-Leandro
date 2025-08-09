using Microsoft.AspNetCore.Mvc;
using Portifolio_Leandro.Models;
using System.Net.Mail;

namespace Portifolio_Leandro.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Send(ContactModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Contact", "Home");
            }

            var smtpSection = _config.GetSection("Smtp");
            var host = smtpSection.GetValue<string>("Host");
            var port = smtpSection.GetValue<int>("Port"); 
            var user = smtpSection.GetValue<string>("UserName");
            var password = smtpSection.GetValue<string>("Password");
            var enabledSsl = smtpSection.GetValue<bool>("EnableSsl");

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(user);
                mail.To.Add(user);
                mail.Subject = model.Subject ?? $"Mensagem de {model.Name}";
                mail.Body = $"Nome: {model.Name}\nEmail: {model.Email}\n\n{model.Message}";

                using var smtp = new SmtpClient(host, port);
                smtp.EnableSsl = enabledSsl;
                smtp.Credentials = new System.Net.NetworkCredential(user, password);
                smtp.Send(mail);

                TempData["Success"] = "Deu certo ze!";
            }
            catch (System.Exception ex)
            {
                TempData["Error"] = "Deu erro ze!";
            }

            return RedirectToAction("Contact", "Home");
        }
    }
}
