using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace mantis_auto
{
    class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = Login(account);
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }
        public void Delete(AccountData account)
        {
            if (!Verify(account))
            {
                return;
            }
            TelnetConnection telnet = Login(account);
             telnet.WriteLine("deluser " + account.Name);
            System.Console.Out.WriteLine(telnet.Read());
        }
       

       public bool Verify(AccountData account)
        {
          
            TelnetConnection telnet = Login(account);
            telnet.WriteLine("verify " + account.Name);
            String answer = telnet.Read();
            System.Console.Out.WriteLine(answer);
            return !answer.Contains("does not exist");
        }

        public TelnetConnection Login(AccountData account)
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            return telnet;
        }
    }
}
