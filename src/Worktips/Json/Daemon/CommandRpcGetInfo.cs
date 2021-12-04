using System.Text.Json.Serialization;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon;

public class CommandRpcGetInfo
{
    public class Response
    {
        /// <summary>
        /// General RPC error code. "OK" means everything looks good.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// Current length of longest chain known to daemon.
        /// </summary>
        [JsonPropertyName("height")]
        public ulong Height { get; set; }

        /// <summary>
        /// The height of the next block in the chain.
        /// </summary>
        [JsonPropertyName("target_height")]
        public ulong TargetHeight { get; set; }

        /// <summary>
        /// The latest height in the blockchain that can not be reorganized from (backed by at least 2 Service Node, or 1 hardcoded checkpoint, 0 if N/A).
        /// </summary>
        [JsonPropertyName("immutable_height")]
        public ulong ImmutableHeight { get; set; }

        /// <summary>
        /// Network difficulty (analogous to the strength of the network)
        /// </summary>
        [JsonPropertyName("difficulty")]
        public ulong Difficulty { get; set; }

        /// <summary>
        /// Current target for next proof of work.
        /// </summary>
        [JsonPropertyName("target")]
        public ulong Target { get; set; }

        /// <summary>
        /// Total number of non-coinbase transaction in the chain.
        /// </summary>
        [JsonPropertyName("tx_count")]
        public ulong TransactionCount { get; set; }

        /// <summary>
        /// Number of transactions that have been broadcast but not included in a block.
        /// </summary>
        [JsonPropertyName("tx_pool_size")]
        public ulong TransactionPoolSize { get; set; }

        /// <summary>
        /// Number of alternative blocks to main chain.
        /// </summary>
        [JsonPropertyName("alt_blocks_count")]
        public ulong AltBlocksCount { get; set; }

        /// <summary>
        /// Number of peers that you are connected to and getting information from.
        /// </summary>
        [JsonPropertyName("outgoing_connections_count")]
        public ulong OutgoingConnectionsCount { get; set; }

        /// <summary>
        /// Number of peers connected to and pulling from your node.
        /// </summary>
        [JsonPropertyName("incoming_connections_count")]
        public ulong IncomingConnectionsCount { get; set; }

        /// <summary>
        /// Number of RPC client connected to the daemon (Including this RPC request).
        /// </summary>
        [JsonPropertyName("rpc_connections_count")]
        public ulong RpcConnectionsCount { get; set; }

        /// <summary>
        /// White Peerlist Size.
        /// </summary>
        [JsonPropertyName("white_peerlist_size")]
        public ulong WhitePeerlistSize { get; set; }

        /// <summary>
        /// Grey Peerlist Size.
        /// </summary>
        [JsonPropertyName("grey_peerlist_size")]
        public ulong GreyPeerlistSize { get; set; }

        /// <summary>
        /// States if the node is on the mainnet (true) or not (false).
        /// </summary>
        [JsonPropertyName("mainnet")]
        public bool Mainnet { get; set; }

        /// <summary>
        /// States if the node is on the testnet (true) or not (false).
        /// </summary>
        [JsonPropertyName("testnet")]
        public bool Testnet { get; set; }

        /// <summary>
        /// States if the node is on the stagenet (true) or not (false).
        /// </summary>
        [JsonPropertyName("stagenet")]
        public bool Stagenet { get; set; }

        /// <summary>
        /// Nettype value used.
        /// </summary>
        [JsonPropertyName("nettype")]
        public string Nettype { get; set; } = null!;

        /// <summary>
        /// Hash of the highest block in the chain.
        /// </summary>
        [JsonPropertyName("top_block_hash")]
        public string TopBlockHash { get; set; } = null!;

        /// <summary>
        /// Hash of the highest block in the chain that can not be reorganized.
        /// </summary>
        [JsonPropertyName("immutable_block_hash")]
        public string ImmutableBlockHash { get; set; } = null!;

        /// <summary>
        /// Cumulative difficulty of all blocks in the blockchain.
        /// </summary>
        [JsonPropertyName("cumulative_difficulty")]
        public ulong CumulativeDifficulty { get; set; }

        /// <summary>
        /// Maximum allowed block size.
        /// </summary>
        [JsonPropertyName("block_size_limit")]
        public ulong BlockSizeLimit { get; set; }

        /// <summary>
        /// Maximum allowed block weight.
        /// </summary>
        [JsonPropertyName("block_weight_limit")]
        public ulong BlockWeightLimit { get; set; }

        /// <summary>
        /// Median block size of latest 100 blocks.
        /// </summary>
        [JsonPropertyName("block_size_median")]
        public ulong BlockSizeMedian { get; set; }

        /// <summary>
        /// Median block weight of latest 100 blocks.
        /// </summary>
        [JsonPropertyName("block_weight_median")]
        public ulong BlockWeightMedian { get; set; }

        /// <summary>
        /// Start time of the daemon, as UNIX time.
        /// </summary>
        [JsonPropertyName("start_time")]
        public ulong StartTime { get; set; }

        /// <summary>
        /// Last ping time of the storage server (0 if never or not running as a service node).
        /// </summary>
        [JsonPropertyName("last_storage_server_ping")]
        public ulong LastStorageServerPing { get; set; }

        /// <summary>
        /// Available disk space on the node.
        /// </summary>
        [JsonPropertyName("free_space")]
        public ulong FreeSpace { get; set; }

        /// <summary>
        /// States if the node is offline (true) or online (false).
        /// </summary>
        [JsonPropertyName("offline")]
        public bool Offline { get; set; }

        /// <summary>
        /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
        /// </summary>
        [JsonPropertyName("untrusted")]
        public bool Untrusted { get; set; }

        /// <summary>
        /// Bootstrap node to give immediate usability to wallets while syncing by proxying RPC to it. (Note: the replies may be untrustworthy).
        /// </summary>
        [JsonPropertyName("bootstrap_daemon_address")]
        public string BootstrapDaemonAddress { get; set; } = null!;

        /// <summary>
        /// Current length of the local chain of the daemon.
        /// </summary>
        [JsonPropertyName("height_without_bootstrap")]
        public ulong HeightWithoutBootstrap { get; set; }

        /// <summary>
        /// States if a bootstrap node has ever been used since the daemon started.
        /// </summary>
        [JsonPropertyName("was_bootstrap_ever_used")]
        public bool WasBootstrapEverUsed { get; set; }

        /// <summary>
        /// Current size of Blockchain data.
        /// </summary>
        [JsonPropertyName("database_size")]
        public ulong DatabaseSize { get; set; }

        /// <summary>
        /// States if a update is available (true) and if one is not available (false).
        /// </summary>
        [JsonPropertyName("update_available")]
        public bool UpdateAvailable { get; set; }

        /// <summary>
        /// Current version of software running.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;
    }
}

[JsonSerializable(typeof(CommandRpcGetInfo.Response), GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class DaemonCommandRpcGetInfoContext : JsonSerializerContext
{
}