using System.Text.Json.Serialization;

namespace ch.jnetwork.fsih.api.model
{
    /// <summary>
    /// Raning Details
    /// </summary>
    public class RankingDetail
    {
        /// <summary>
        /// Played Games
        /// </summary>
        [JsonPropertyName("gp")]
        public int GamesPlayed { get; set; }

        /// <summary>
        /// Totals goals received
        /// </summary>
        [JsonPropertyName("ga")]
        public int GoalsReceive { get; set; }

        /// <summary>
        ///  Total goals scored
        /// </summary>
        [JsonPropertyName("gf")]
        public int GoalsScored { get; set; }

        /// <summary>
        /// Total games loose
        /// </summary>
        [JsonPropertyName("l")]
        public int Loose { get; set; }

        /// <summary>
        /// Total games loose in overtime
        /// </summary>
        [JsonPropertyName("otl")]
        public int LooseOvertime { get; set; }

        /// <summary>
        /// Total games loose in penalty killing
        /// </summary>
        [JsonPropertyName("sol")]
        public int LoosePenalty { get; set; }

        /// <summary>
        /// Total points of team
        /// </summary>
        [JsonPropertyName("pts")]
        public int Points { get; set; }

        /// <summary>
        /// Total games win
        /// </summary>
        [JsonPropertyName("w")]
        public int Win { get; set; }

        /// <summary>
        /// Total games win in overtime
        /// </summary>
        [JsonPropertyName("otw")]
        public int WinOvertime { get; set; }

        /// <summary>
        /// Total games win in penalty killing
        /// </summary>
        [JsonPropertyName("sow")]
        public int WinPenalty { get; set; }
    }
}