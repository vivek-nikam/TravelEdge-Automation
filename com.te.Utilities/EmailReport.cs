using System;
using System.Net.Mail;


namespace ADX_Regression.ControlUnit
{
    class EmailReport : ExtentReport
    {
        public void Email()
        {
            try
            {
                SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
                mailServer.EnableSsl = true;

                mailServer.Credentials = new System.Net.NetworkCredential("vivek.nikam@galepartners.com", "V1vekN1kam$");

                string from = "vivek.nikam@galepartners.com";
                string to = "adx.bcc.uat@traveledge.com";
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = "Automation Report";
                msg.Body = "Please open the attachment to view the htmlreport";
                msg.Attachments.Add(new Attachment("C:\\Users\\user\\Documents\\visual studio 2017\\Projects\\ADX_Regression\\ADX_Regression\\Reports\\TravelEdge.html"));
                mailServer.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to send email. Error : " + ex);
            }
        }
    }
}
