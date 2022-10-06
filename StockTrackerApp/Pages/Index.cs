using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;

namespace StockTrackerApp.Pages
{
    public partial class Index
    {
        static string YahooFinance = "https://finance.yahoo.com/quote/TICKER?p=TICKER&.tsrc=fin-srch;";
        static string TipRanks = "https://www.tipranks.com/stocks/TICKER/forecast";
        static string MorningStar = "https://www.morningstar.com/stocks/xsgo/TICKER/quote";
        static string StockChart = "https://stockcharts.com/h-sc/ui?s=TICKER";
        string symbol = String.Empty;
        List<string> symbols = new List<string>();
        List<string> yahoofinances = new List<string>();
        List<string> tipranks = new List<string>();
        List<string> morningStars = new List<string>();
        List<string> stockCharts = new List<string>();
        private async Task OnSearchCallBack()
        {
            if (String.IsNullOrEmpty(symbol.Trim()))
                return;

            var yahooFinance = YahooFinance.Replace("TICKER", symbol);
            var tipRank = TipRanks.Replace("TICKER", symbol);
            var morningStar = MorningStar.Replace("TICKER", symbol);
            var stockChart = StockChart.Replace("TICKER", symbol);

            yahoofinances.Add(yahooFinance);
            tipranks.Add(tipRank);
            morningStars.Add(morningStar);
            stockCharts.Add(stockChart);
            symbols.Add(symbol);

            symbol = String.Empty;
            await Task.CompletedTask;
        }
    }
}
