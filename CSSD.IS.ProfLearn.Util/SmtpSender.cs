using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace CSSD.IS.ProfLearn.Util
{
    public class SmtpSender
    {
        private string _SendTo;

        public string SendTo
        {
            get { return _SendTo; }
            set { _SendTo = value; }
        }
        private string _SendFrom;

        public string SendFrom
        {
            get { return _SendFrom; }
            set { _SendFrom = value; }
        }

        private string _MailServer;

        public string MailServer
        {
            get { return _MailServer; }
            set { _MailServer = value; }
        }

        private string _Subject;

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        private string _Body;

        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }

        private string _AttachmentFileName;

        public string AttachmentFileName
        {
            get { return _AttachmentFileName; }
            set { _AttachmentFileName = value; }
        }

        public void SendMail(Boolean htmlTag)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SendFrom);
            string[] sendTo = SendTo.Split(';');
            for (int i = 0; i < sendTo.Length; i++)
            {
                mail.To.Add(sendTo[i]);
            }
            if (htmlTag)
            {
                mail.IsBodyHtml = true;
            }
            mail.Subject = Subject;
            mail.Body = Body;

            if (File.Exists(AttachmentFileName))
            {
                mail.Attachments.Add(new Attachment(AttachmentFileName));
            }
            SmtpClient smtp = new SmtpClient(MailServer);
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                AppLog.GetAppLog().Log("Error in sending email message: " + mail.To.ToString() + "" + ex.Message);
            }
            finally
            {
                mail.Dispose();
                smtp = null;
            }
        }
    }
}
