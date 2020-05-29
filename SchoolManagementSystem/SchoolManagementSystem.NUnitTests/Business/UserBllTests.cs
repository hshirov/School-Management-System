using Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementSystem.NUnitTests.Business
{
    [TestFixture]
    class UserBllTests
    {
        [Test]
        public void HashPassword_Returns_HashString()
        {
            UserBll userBll = new UserBll();
            string stringPassword = "pa$$w0rd1337";
            string hashPassword = userBll.HashPassword(stringPassword);

            // SHA256 hash is always 64 characters
            Assert.IsTrue(hashPassword.Length == 64);
        }
    }
}
