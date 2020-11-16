using RestSharp;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CryptoApp.Model;

namespace CryptoApp
{
    public partial class MainPage : ContentPage
    {

        private string apiKey = "91B040B7-5087-4873-AC12-3E5151FE6B10";
        private string baseImageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";

        public MainPage()
        {
            InitializeComponent();
            coinListView.ItemsSource = GetCoins();
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            coinListView.ItemsSource = GetCoins();
        }

        private List<Coin> GetCoins()
        {
            List<Coin> coins;

            var client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;LTC;XMR;XRP;DASH");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);

            var response = client.Execute(request);

            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                if (!String.IsNullOrEmpty(c.Id_Icon))
                    c.Icon_Url = baseImageUrl + c.Id_Icon.Replace("-", "") + ".png";
                else
                    c.Icon_Url = "";
            }

            return coins;
        }
    }
}
