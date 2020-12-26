using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace AegisWebsite
{
    public class Utility
    {
        public static bool MailFunctionality(string name, string email, string phone, string comment)
        {
            try
            {
                string body = "From: " + name.Trim() + "<br/>";
                body += "Email: " + email.Trim() + "<br/>";
                body += "Phone: " + phone.Trim() + "<br/>";
                body += "Comment: \n" + comment.Trim() + "<br/>";

                MailMessage emailMessage = new MailMessage();
                emailMessage.To.Add("info@aegissolutions.in");
                //email.CC.Add(txtcemail.Text);
                emailMessage.From = new MailAddress("no_reply@aegissolutions.in", "Enquiry from website");
                emailMessage.IsBodyHtml = true;
                emailMessage.Subject = "Client details";
                emailMessage.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = false;
                smtp.Port = 25;
                smtp.Host = "mail.aegiscrm.in"; //Or Your SMTP Server Address
                smtp.Credentials = new
                System.Net.NetworkCredential("no_reply@aegissolutions.in", "P@ssw0rd");
                smtp.Send(emailMessage);

                return true;
            }
            catch(Exception ex)
            {
            
            }
            return false;
        }
    }
}