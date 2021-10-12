using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Windows;
using RestSharp;
using System.IO;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public  void TestMethod1()
        {
               var db = new PlanetDB();
               db.SolarSystem.RemoveRange(db.SolarSystem);
               db.SaveChanges();
         
               

          }
    }
}