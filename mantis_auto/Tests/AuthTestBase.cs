using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_auto
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetUpLogin()
        {
            app.Login.LoginToTheSystem(new AccountData("administrator", "root"));
        }

        /*[Test]
        public void Logout()

        {
            app.Login.LogOut();
        }*/
    }
}
