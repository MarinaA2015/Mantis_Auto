using System;
using NUnit.Framework;


namespace mantis_auto
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            AccountData acc = new AccountData()
            {
                Name = "XXX",
                Password = "YYY"
            };
            Assert.IsFalse(app.James.Verify(acc));
            app.James.Add(acc);
            Assert.IsTrue(app.James.Verify(acc));
            app.James.Delete(acc);
            Assert.IsFalse(app.James.Verify(acc));

        }
    }
}
