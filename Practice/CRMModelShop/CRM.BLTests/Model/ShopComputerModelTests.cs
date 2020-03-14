using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CRM.BL.Model.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void StartTest()
        {
            ShopComputerModel model = new ShopComputerModel();
            model.Start();
            Thread.Sleep(10000);
        }
    }
}