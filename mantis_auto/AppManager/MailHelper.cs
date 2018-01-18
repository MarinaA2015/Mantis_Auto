using System;
using OpaqueMail.Net;
//using OpaqueMail;

namespace mantis_auto
{
    public class MailHelper : HelperBase
    {
        public MailHelper(ApplicationManager manager) : base(manager)
        {
        }

        public String GetLastMail(AccountData account)
        {
            
           // System.Threading.Thread.Sleep(2000);
            //int count = pop3.GetMessageCount();

            for (int i = 0; i < 20; i++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.Name, account.Password, false);
                pop3.Connect();
                pop3.Authenticate();

                if (pop3.GetMessageCount() > 0)
                {
                    // return pop3.GetMessage(1).Body;
                    ReadOnlyMailMessage message = pop3.GetMessage(1);
                    string body = message.Body;
                    pop3.DeleteMessage(1);
                    pop3.LogOut();
                    return body;
                }

                else
                {
                    System.Threading.Thread.Sleep(2000);
                }                
            }
            return null;
        }
    }
}
