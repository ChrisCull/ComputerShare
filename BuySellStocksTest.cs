using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ComputerShare_Stocks
{
    [TestClass]
    public class BuySellStocksTest
    {
        [TestMethod]
        public void TestOutput()
        {
            BuySellStocks buySell = new BuySellStocks();
            string file = @"C:\Computershare Unit Tests\ChallengeSampleDataSet2.txt";
            string result = buySell.BestBuySell(file);
            Assert.AreEqual("20(15.79),21(26.19)", result);
        }
    }
}
