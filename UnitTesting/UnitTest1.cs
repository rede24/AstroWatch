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
        public  void TestMethod1()
        {
            var dal = new DAL.Dal();
            var res =  DAL.Util<NearEarthObjectRoot>.PerformHttpRequest("http://www.neowsapp.com/rest/v1/feed?start_date=2021-10-05&end_date=2021-10-12&detailed=false&api_key=DEMO_KEY");
            Task.WaitAll(res);
            res.Result.near_earth_objects.date.Add[0]
            int a = 1;



        }
    }
}