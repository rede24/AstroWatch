using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
     [TestClass]
     public class UnitTest1
     {
          [TestMethod]
          public void TestMethod1()
          {
            var dal = new DAL.Dal();
                var res = dal.GetImageOfTheDayFromNASAApi().Result;
            Assert.IsNotNull(res.url);
          

          }
     }
}
