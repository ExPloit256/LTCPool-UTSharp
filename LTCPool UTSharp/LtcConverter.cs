using System;
using System.Collections.Generic;

namespace LTCPool_UTSharp
{
    public static class LtcConverter
    {
        private static Dictionary<Currencies, CurrencyData> rates;

        static LtcConverter()
        {
            rates = new Dictionary<Currencies, CurrencyData>()
            {
                { Currencies.Ltc, new CurrencyData(0, "Ł") },
                { Currencies.Btc, new CurrencyData(0, "₿") },
                { Currencies.Usd, new CurrencyData(0, "$") },
                { Currencies.Cad, new CurrencyData(0, "CAD$") },
                { Currencies.Eur, new CurrencyData(0, "€") },
                { Currencies.Gbp, new CurrencyData(0, "£") },
                { Currencies.Rub, new CurrencyData(0, "₽") },
                { Currencies.Cny, new CurrencyData(0, "¥") },
                { Currencies.Aud, new CurrencyData(0, "AUD$") },
                { Currencies.Zar, new CurrencyData(0, "R") },
            };
        }

        public static void Update(in Data.Market market)
        {
            rates[Currencies.Btc].ltcExchange = market.ltc_btc;
            rates[Currencies.Usd].ltcExchange = market.ltc_usd;
            rates[Currencies.Cad].ltcExchange = market.ltc_cad;
            rates[Currencies.Eur].ltcExchange = market.ltc_eur;
            rates[Currencies.Gbp].ltcExchange = market.ltc_gbp;
            rates[Currencies.Rub].ltcExchange = market.ltc_rub;
            rates[Currencies.Cny].ltcExchange = market.ltc_cny;
            rates[Currencies.Aud].ltcExchange = market.ltc_aud;
            rates[Currencies.Zar].ltcExchange = market.ltc_zar;
        }

        public static double ConvertTo(double ltc, Currencies currency)
        {
            return ltc * rates[currency].ltcExchange;
        }

        public static string ToString(double ltc, Currencies currency, int decimalDigits = 2)
        {
            var data = rates[currency];
            var value = ltc * data.ltcExchange;
            return value.ToString("N" + decimalDigits) + data.symbol;
        }

        private class CurrencyData
        {
            public double ltcExchange;
            public string symbol;

            public CurrencyData(double ltcExchange, string symbol)
            {
                this.ltcExchange = ltcExchange;
                this.symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
            }
        }
    }
}
