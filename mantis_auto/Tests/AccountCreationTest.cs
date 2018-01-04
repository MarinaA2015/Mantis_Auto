using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_auto
{
    
    [TestFixture]
    public class AccountCreationTest : TestBase
    {
       
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@lovalhost.localdomain"
            };
            app.Registration.Register(account);
        }

    
    }
}
