using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.Numerics;

namespace LTCPool_UTSharp
{
    public class Data
    {
        [JsonProperty] public readonly User user;
        [JsonProperty] public readonly JObject workers;
        [JsonProperty] public readonly JObject[] recent_payouts;
        [JsonProperty] public readonly Pool pool;
        [JsonProperty] public readonly Network network;
        [JsonProperty] public readonly Market market;

        public readonly struct User 
        {
            [JsonProperty] public readonly ulong hash_rate;
            [JsonProperty] public readonly double expected_24h_rewards;
            [JsonProperty] public readonly double total_rewards;
            [JsonProperty] public readonly double paid_rewards;
            [JsonProperty] public readonly double unpaid_rewards;
            [JsonProperty] public readonly double past_24h_rewards;
            [JsonProperty] public readonly BigInteger total_work;
            [JsonProperty] public readonly ulong blocks_found;
        }

        public readonly struct Pool
        {
            [JsonProperty] public readonly ulong hash_rate;
            [JsonProperty] public readonly ulong active_users;
            [JsonProperty] public readonly ulong active_workers;
            [JsonProperty] public readonly BigInteger total_work;
            [JsonProperty] public readonly double pps_ratio;
            [JsonProperty] public readonly double pps_rate;
        }

        public readonly struct Network
        {
            [JsonProperty] public readonly ulong hash_rate;
            [JsonProperty] public readonly ulong block_number;
            [JsonProperty] public readonly ulong time_per_block;
            [JsonProperty] public readonly double difficulty;
            [JsonProperty] public readonly double next_difficulty;
            [JsonProperty] public readonly ulong retarget_time;

        }

        public readonly struct Market
        {
            [JsonProperty] public readonly double ltc_btc;
            [JsonProperty] public readonly double ltc_usd;
            [JsonProperty] public readonly double ltc_cad;
            [JsonProperty] public readonly double ltc_eur;
            [JsonProperty] public readonly double ltc_gbp;
            [JsonProperty] public readonly double ltc_rub;
            [JsonProperty] public readonly double ltc_cny;
            [JsonProperty] public readonly double ltc_aud;
            [JsonProperty] public readonly double ltc_zar;
            [JsonProperty] public readonly double btc_usd;
        }
    }
}
