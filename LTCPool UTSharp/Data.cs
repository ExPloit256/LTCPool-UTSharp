using Newtonsoft.Json.Linq;

using System.Numerics;

namespace LTCPool_UTSharp
{
    public class Data
    {
        public User user;
        public JObject workers;
        public JObject[] recent_payouts;
        public Pool pool;
        public Network network;
        public Market market;

        public struct User 
        {
            public ulong hash_rate;
            public double expected_24h_rewards;
            public double total_rewards;
            public double paid_rewards;
            public double unpaid_rewards;
            public double past_24h_rewards;
            public ulong total_work;
            public ulong blocks_found;
        }

        public struct Pool
        {
            public ulong hash_rate;
            public ulong active_users;
            public ulong active_workers;
            public BigInteger total_work;
            public double pps_ratio;
            public double pps_rate;
        }

        public struct Network
        {
            public ulong hash_rate;
            public ulong block_number;
            public ulong time_per_block;
            public double difficulty;
            public double next_difficulty;
            public ulong retarget_time;

        }

        public struct Market
        {
            public double ltc_btc;
            public double ltc_usd;
            public double ltc_cad;
            public double ltc_eur;
            public double ltc_gbp;
            public double ltc_rub;
            public double ltc_cny;
            public double ltc_aud;
            public double ltc_zar;
            public double btc_usd;
        }
    }
}
