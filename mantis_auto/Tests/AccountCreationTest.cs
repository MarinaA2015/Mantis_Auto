﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_auto
{
    
    [TestFixture]
    public class AccountCreationTest : TestBase
    {
        [TestFixtureSetUp]
       public void SetupConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localFile = File.Open("./config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
            }
                
               
        }
        [Test]
        public void TestAccountRegistration()
        {
            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData account = new AccountData("testuser47", "password")
            {
           
                Email = "testuser47@localhost.localdomain"
            };
            //accounts.Find(x=>x.Name == account.Name);
            if (accounts.Contains(account))
            {
                AccountData acc = accounts.Find(x=>x.Name == account.Name);
                app.Admin.DeleteAccount(acc);
            }
            
            app.James.Delete(account);
            app.James.Add(account);

            Console.Out.WriteLine("exists? "+ app.James.Verify(account));
            Console.Out.WriteLine(account.Name);
            Console.Out.WriteLine(account.Password);
            if (app.Login.IsLoggedIn())
                app.Login.LogOut();
            System.Threading.Thread.Sleep(1000);
                app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }


    
    }
}
