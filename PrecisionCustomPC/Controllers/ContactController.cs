using System.Net;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using PrecisionCustomPC.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace PrecisionCustomPC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Submit(ContactForm form)
        {
            if (ModelState.IsValid)
            {
                var body = new TextPart("html")
                {
                    Text = "<html style=\"margin:0; padding:0;\">" +
                            "<head>" +
                            "</head>" +
                            "<body style=\"margin:0; padding:0;\">" +
                                "<div style=\"position:relative; display:block; padding:0em 0em; height:9em; font-family:sans-serif; background:#020;\">" +
                                    "<span style=\"position:relative; display:inline-block; width:20em; margin-left:3em;\">" +
                                        "<p style=\"position:relative; display:block; color:#ddd; font-size:2em; line-height:0.5em;\">" + form.FirstName + " " + form.LastName + "</p>" +
                                        "<p style=\"position:relative; display:block; color:#ddd; font-size:1em; line-height:0.7em;\">" + form.Phone + "</p>" +
                                        "<p style=\"position:relative; display:block; color:#ddd; font-size:1em; line-height:0.7em;\">" + form.Email + "</p>" +
                                    "</span>" +
                                    "<span style=\"position:absolute; display:inline-block; color:#ddd; font-size:4em;\">" + form.Company + "</span>" +
                                "</div>" +
                                "<div style=\"position:relative; display:block; padding:1em 3em; font-family:sans-serif; background:#ddd;\">" +
                                    "<span style=\"position:relative; display:block; padding:0.3em 0; color:#020; font-size:1.5em;\">Min Price: $" + form.Min + ".00</span>" +
                                    "<span style=\"position:relative; display:block; padding:0.3em 0; color:#020; font-size:1.5em;\">Max Price: $" + form.Max + ".00</span>" +
                                    "<p style=\"position:relative; display:block; padding:1em 0; color:#020; font-size:1.2em; border-top:1px solid #020;\">" + form.Msg + "</p>" +
                                "</div>" +
                            "</body>" +
                            "</html>"
                };
                var message = new MimeMessage();
                message.To.Add(new MailboxAddress("precisioncustompc@gmail.com"));  // replace with valid value 
                message.From.Add(new MailboxAddress(form.Email));  // replace with valid value
                message.Subject = "Business Contact: " + form.Company;
                message.Body = body;

                using (var smtp = new SmtpClient())
                {
                    // Accept all SSL certificates (in case the server supports STARTTLS)
                    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    smtp.Connect("smtp.secureserver.net", 587, false);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    smtp.AuthenticationMechanisms.Remove("XOAUTH2");

                    smtp.Send(message);
                    smtp.Disconnect(true);
                }
            }
            return View("Index", form);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}