using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class BlockHeaderResponse
{
    /// <summary>
    /// The major version of the worktips protocol at this block height.
    /// </summary>
    [JsonPropertyName("major_version")]
    public byte MajorVersion { get; set; }

    /// <summary>
    /// The minor version of the worktips protocol at this block height.
    /// </summary>
    [JsonPropertyName("minor_version")]
    public byte MinorVersion { get; set; }

    /// <summary>
    /// The unix time at which the block was recorded into the blockchain.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public ulong Timestamp { get; set; }

    /// <summary>
    /// The hash of the block immediately preceding this block in the chain.
    /// </summary>
    [JsonPropertyName("prev_hash")]
    public string PreviousHash { get; set; } = null!;

    /// <summary>
    /// A cryptographic random one-time number used in mining a Worktips block.
    /// </summary>
    [JsonPropertyName("nonce")]
    public uint Nonce { get; set; }

    /// <summary>
    /// Usually false. If true, this block is not part of the longest chain.
    /// </summary>
    [JsonPropertyName("orphan_status")]
    public bool OrphanStatus { get; set; }

    /// <summary>
    /// The number of blocks preceding this block on the blockchain.
    /// </summary>
    [JsonPropertyName("height")]
    public ulong Height { get; set; }

    /// <summary>
    /// The number of blocks succeeding this block on the blockchain. A larger number means an older block.
    /// </summary>
    [JsonPropertyName("depth")]
    public ulong Depth { get; set; }

    /// <summary>
    /// The hash of this block.
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; set; } = null!;

    /// <summary>
    /// The strength of the Worktips network based on mining power.
    /// </summary>
    [JsonPropertyName("difficulty")]
    public ulong Difficulty { get; set; }

    /// <summary>
    /// The cumulative strength of the Worktips network based on mining power.
    /// </summary>
    [JsonPropertyName("cumulative_difficulty")]
    public ulong CumulativeDifficulty { get; set; }

    /// <summary>
    /// The amount of new generated in this block and rewarded to the miner, foundation and service Nodes. Note: 1 WORKTIPS = 1e12 atomic units.
    /// </summary>
    [JsonPropertyName("reward")]
    public ulong Reward { get; set; }

    /// <summary>
    /// The amount of new generated in this block and rewarded to the miner. Note: 1 WORKTIPS = 1e12 atomic units.
    /// </summary>
    [JsonPropertyName("miner_reward")]
    public ulong MinerReward { get; set; }

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    [JsonPropertyName("block_size")]
    public ulong BlockSize { get; set; }

    /// <summary>
    /// The block weight in bytes.
    /// </summary>
    [JsonPropertyName("block_weight")]
    public ulong BlockWeight { get; set; }

    /// <summary>
    /// Number of transactions in the block, not counting the coinbase tx.
    /// </summary>
    [JsonPropertyName("num_txes")]
    public ulong TransactionsCount { get; set; }

    /// <summary>
    /// The hash of the block's proof of work.
    /// </summary>
    [JsonPropertyName("pow_hash")]
    public string PowHash { get; set; } = null!;

    /// <summary>
    /// Long term weight of the block.
    /// </summary>
    [JsonPropertyName("long_term_weight")]
    public ulong LongTermWeight { get; set; }

    /// <summary>
    /// The TX hash of the miner transaction.
    /// </summary>
    [JsonPropertyName("miner_tx_hash")]
    public string MinerTransactionHash { get; set; } = null!;

    /// <summary>
    /// Service node that received a reward for this block.
    /// </summary>
    [JsonPropertyName("service_node_winner")]
    public string ServiceNodeWinner { get; set; } = null!;
}