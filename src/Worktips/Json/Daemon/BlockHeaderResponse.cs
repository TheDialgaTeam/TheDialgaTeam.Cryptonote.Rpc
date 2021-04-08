using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class BlockHeaderResponse
    {
        [JsonProperty("major_version")]
        public byte MajorVersion { get; set; }

        [JsonProperty("minor_version")]
        public byte MinorVersion { get; set; }

        [JsonProperty("timestamp")]
        public ulong Timestamp { get; set; }

        [JsonProperty("prev_hash")]
        public string PreviousHash { get; set; }

        [JsonProperty("nonce")]
        public uint Nonce { get; set; }

        [JsonProperty("orphan_status")]
        public bool OrphanStatus { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("depth")]
        public ulong Depth { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("difficulty")]
        public ulong Difficulty { get; set; }

        [JsonProperty("cumulative_difficulty")]
        public ulong CumulativeDifficulty { get; set; }

        [JsonProperty("reward")]
        public ulong Reward { get; set; }

        [JsonProperty("miner_reward")]
        public ulong MinerReward { get; set; }

        [JsonProperty("block_size")]
        public ulong BlockSize { get; set; }

        [JsonProperty("block_weight")]
        public ulong BlockWeight { get; set; }

        [JsonProperty("num_txes")]
        public ulong NumberOfTransactions { get; set; }

        [JsonProperty("pow_hash")]
        public string PowHash { get; set; }

        [JsonProperty("long_term_weight")]
        public ulong LongTermWeight { get; set; }
    }
}