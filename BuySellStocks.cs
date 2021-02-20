using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ComputerShare_Stocks
{
    class BuySellStocks
    {

        // BuySellPair object which holds the lowest buy price/highest sell price + their corresponding days.
        private class BuySellPair
        {
            public int lowDay { get; set; }
            public int highDay { get; set; }
            public decimal lowPrice { get; set; }
            public decimal highPrice { get; set; }
        }

        // given a path to a text file it will return the best buy/sell days
        public string BestBuySell(string path)
        {
            try
            {
                // get the list of prices from the file
                List<decimal> prices = ProcessFile(path);

                // create the buySellPair object with default values.
                BuySellPair buySellPair = new BuySellPair { highDay = 0, lowDay = 0, highPrice = 0, lowPrice = 0 };

                // loop through the list of prices
                for (int i = 0; i < prices.Count; i++)
                {
                    // for every price check each remaining price
                    for (int j = i + 1; j < prices.Count; j++)
                    {
                        // if j - i is greater than the current best buy/sell margin make it the new best margin.
                        if (prices[j] - prices[i] > buySellPair.highPrice - buySellPair.lowPrice)
                        {
                            // assign low/high properties to the buySellPairObject
                            buySellPair.lowPrice = prices[i];
                            buySellPair.highPrice = prices[j];
                            buySellPair.lowDay = i + 1;
                            buySellPair.highDay = j + 1;
                        }
                    }
                }
                // printing in the format provided - buyDay(buyPrice),sellDay(sellPrice)
                if (buySellPair.lowDay == Int32.MinValue)
                    return "There was no suitable buy date as stock prices never increased.";
                else
                    return $"{buySellPair.lowDay}({buySellPair.lowPrice}),{buySellPair.highDay}({buySellPair.highPrice})";
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // helper method for processing the text file in the corresponding path
        private List<decimal> ProcessFile(string path)
        {
            try
            {
                List<decimal> prices = new List<decimal>();
                var lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i += 1)
                { 
                    var line = lines[i];
                    string[] unprocessedFloats = line.Split(',');
                    foreach (var price in unprocessedFloats)
                    {
                        prices.Add(decimal.Parse(price.ToString()));
                    }
                }
                return prices;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
