using Newtonsoft.Json;

namespace TheDialgaTeam.Cryptonote.Rpc.Worktips.Json.Daemon
{
    public class CommandRpcGetInfo
    {
        public class Response
        {
            /// <summary>
            /// General RPC error code. "OK" means everything looks good.
            /// </summary>
            [JsonProperty("Status")]
            public string Status { get; set; }

            /// <summary>
            /// Current length of longest chain known to daemon.
            /// </summary>
            [JsonProperty("Height")]
            public ulong Height { get; set; }

            /// <summary>
            /// The height of the next block in the chain.
            /// </summary>
            [JsonProperty("target_height")]
            public ulong TargetHeight { get; set; }

            /// <summary>
            /// Network difficulty (analogous to the strength of the network)
            /// </summary>
            [JsonProperty("difficulty")]
            public ulong Difficulty { get; set; }

            /// <summary>
            /// Current target for next proof of work.
            /// </summary>
            [JsonProperty("target")]
            public ulong Target { get; set; }

            /// <summary>
            /// Total number of non-coinbase transaction in the chain.
            /// </summary>
            [JsonProperty("tx_count")]
            public ulong TxCount { get; set; }

            /// <summary>
            /// Number of transactions that have been broadcast but not included in a block.
            /// </summary>
            [JsonProperty("tx_pool_size")]
            public ulong TxPoolSize { get; set; }

            /// <summary>
            /// Number of alternative blocks to main chain.
            /// </summary>
            [JsonProperty("alt_blocks_count")]
            public ulong AltBlocksCount { get; set; }

            /// <summary>
            /// Number of peers that you are connected to and getting information from.
            /// </summary>
            [JsonProperty("outgoing_connections_count")]
            public ulong OutgoingConnectionsCount { get; set; }

            /// <summary>
            /// Number of peers connected to and pulling from your node.
            /// </summary>
            [JsonProperty("incoming_connections_count")]
            public ulong IncomingConnectionsCount { get; set; }

            /// <summary>
            /// Number of RPC client connected to the daemon (Including this RPC request).
            /// </summary>
            [JsonProperty("rpc_connections_count")]
            public ulong RpcConnectionsCount { get; set; }

            /// <summary>
            /// White Peerlist Size.
            /// </summary>
            [JsonProperty("white_peerlist_size")]
            public ulong WhitePeerlistSize { get; set; }

            /// <summary>
            /// Grey Peerlist Size.
            /// </summary>
            [JsonProperty("grey_peerlist_size")]
            public ulong GreyPeerlistSize { get; set; }

            /// <summary>
            /// States if the node is on the mainnet (true) or not (false).
            /// </summary>
            [JsonProperty("mainnet")]
            public bool Mainnet { get; set; }

            /// <summary>
            /// States if the node is on the testnet (true) or not (false).
            /// </summary>
            [JsonProperty("testnet")]
            public bool Testnet { get; set; }

            /// <summary>
            /// States if the node is on the stagenet (true) or not (false).
            /// </summary>
            [JsonProperty("stagenet")]
            public bool Stagenet { get; set; }

            [JsonProperty("nettype")]
            public string Nettype { get; set; }

            /// <summary>
            /// Hash of the highest block in the chain.
            /// </summary>
            [JsonProperty("top_block_hash")]
            public string TopBlockHash { get; set; }

            /// <summary>
            /// Cumulative difficulty of all blocks in the blockchain.
            /// </summary>
            [JsonProperty("cumulative_difficulty")]
            public ulong CumulativeDifficulty { get; set; }

            /// <summary>
            /// Maximum allowed block size.
            /// </summary>
            [JsonProperty("block_size_limit")]
            public ulong BlockSizeLimit { get; set; }

            [JsonProperty("block_weight_limit")]
            public ulong BlockWeightLimit { get; set; }

            /// <summary>
            /// Median block size of latest 100 blocks.
            /// </summary>
            [JsonProperty("block_size_median")]
            public ulong BlockSizeMedian { get; set; }

            [JsonProperty("block_weight_median")]
            public ulong BlockWeightMedian { get; set; }

            /// <summary>
            /// Start time of the daemon, as UNIX time.
            /// </summary>
            [JsonProperty("start_time")]
            public ulong StartTime { get; set; }

            /// <summary>
            /// Available disk space on the node.
            /// </summary>
            [JsonProperty("free_space")]
            public ulong FreeSpace { get; set; }

            /// <summary>
            /// States if the node is offline (true) or online (false).
            /// </summary>
            [JsonProperty("offline")]
            public bool Offline { get; set; }

            /// <summary>
            /// States if the result is obtained using the bootstrap mode, and is therefore not trusted (true), or when the daemon is fully synced (false).
            /// </summary>
            [JsonProperty("untrusted")]
            public bool Untrusted { get; set; }

            /// <summary>
            /// Bootstrap node to give immediate usability to wallets while syncing by proxying RPC to it. (Note: the replies may be untrustworthy).
            /// </summary>
            [JsonProperty("bootstrap_daemon_address")]
            public string BootstrapDaemonAddress { get; set; }

            /// <summary>
            /// Current length of the local chain of the daemon.
            /// </summary>
            [JsonProperty("height_without_bootstrap")]
            public ulong HeightWithoutBootstrap { get; set; }

            /// <summary>
            /// States if a bootstrap node has ever been used since the daemon started.
            /// </summary>
            [JsonProperty("was_bootstrap_ever_used")]
            public bool WasBootstrapEverUsed { get; set; }

            [JsonProperty("database_size")]
            public ulong DatabaseSize { get; set; }

            [JsonProperty("update_available")]
            public bool UpdateAvailable { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }
        }
    }
}