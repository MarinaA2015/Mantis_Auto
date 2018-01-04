using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_auto
{
    
    [TestFixture]
    public class LoginTest : AuthTestBase
    {
       
        [Test]
        public void TestLogin()
        {
            app.Login.LogOut();
            app.Login.LoginToTheSystem(new AccountData("administrator", "root"));

        }
    }
}
