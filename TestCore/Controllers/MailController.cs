using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TestCore.Models;
using System.Text;
using System.Diagnostics;

namespace TestCore.Controllers
{
    [Route("mail")]
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Send([FromForm] MailModel model)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(model.From);

                foreach (var email in model.To.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mail.To.Add(email);
                }

                //foreach (var email in model.Cc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    mail.Bcc.Add(email);
                //}

                mail.SubjectEncoding = Encoding.UTF8;
                mail.Subject = model.Title;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Body = model.Body;

                //using (var client = new SmtpClient("smtp.gmail.com", 465))
                using (var client = new SmtpClient("192.168.100.4", 25))
                {
                    client.Send(mail);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occure! : " + ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

      
    }
}