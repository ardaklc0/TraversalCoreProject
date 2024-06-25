using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequestModel model)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "netcoretestmail0@gmail.com");
            message.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            message.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = model.Body;
            message.Body = bodyBuilder.ToMessageBody();
            message.Subject = model.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("netcoretestmail0@gmail.com", "afxhjwuxiwujpwdd"); 

            smtpClient.Send(message);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
