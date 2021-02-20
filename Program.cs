using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ComputerShare_Stocks
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                BuySellStocks buySell = new BuySellStocks();
                // insert the path to stock text file
                Console.WriteLine("Insert path to text file of stock prices here: ");
                string path = Console.ReadLine();
                // call the BestBuySell class which will return the formatted output of the best buy/sell days + prices.
                string result = buySell.BestBuySell(path);
                Console.WriteLine(result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
