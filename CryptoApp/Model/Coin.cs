using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Model
{
    public class Coin
    {
        public string Asset_Id { get; set; }
        public string Name { get; set; }
        public float Price_usd { get; set; }
        public string Id_Icon { get; set; }
        public string Icon_Url { get; set; }
    }
}
