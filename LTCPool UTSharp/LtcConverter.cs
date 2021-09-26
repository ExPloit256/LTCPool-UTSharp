using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTCPool_UTSharp
{
    public static class LtcConverter
    {
        public static Dictionary<Currencies, double> rates;

        static LtcConverter()
        {
            rates = new Dictionary<Currencies, double>()
            {
                { Currencies.Btc, 0 },
                { Currencies.Usd, 0 },
                { Currencies.Cad, 0 },
                { Currencies.Eur, 0 },
                { Currencies.Gbp, 0 },
                { Currencies.Rub, 0 },
                { Currencies.Cny, 0 },
                { Currencies.Aud, 0 },
                { Currencies.Zar, 0 },
            };
        }

        public static void Update(in Data.Market market)
        {
            rates[Currencies.Btc] = market.ltc_btc;
            rates[Currencies.Usd] = market.ltc_usd;
            rates[Currencies.Cad] = market.ltc_cad;
            rates[Currencies.Eur] = market.ltc_eur;
            rates[Currencies.Gbp] = market.ltc_gbp;
            rates[Currencies.Rub] = market.ltc_rub;
            rates[Currencies.Cny] = market.ltc_cny;
            rates[Currencies.Aud] = market.ltc_aud;
            rates[Currencies.Zar] = market.ltc_zar;
        }

        public static double ConvertTo(double ltc, Currencies currency)
        {
            return ltc * rates[currency];
        }
    }
}
