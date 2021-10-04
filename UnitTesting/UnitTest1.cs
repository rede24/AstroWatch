using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Windows;
using RestSharp;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dal = new DAL.Dal();
            var res = Task.Run(() => dal.GetSearchResult("mars"));

            while (!res.IsCompleted)
            {


            }

            int ccc = res.Result.Count;
            foreach (var item in res.Result)
            {
               var d = item;

            }
        }


    }
}