using System.Text.Json.Serialization;

namespace ch.jnetwork.fsih.api.dto
{
    /// <summary>
    /// Main Ranking Object
    /// </summary>
    public class Ranking
    {
        /// <summary>
        /// Ranking Details with Points, Looses, Wins, etc
        /// </summary>
        [JsonPropertyName("ranking")]
        public RankingDetail RankingDetails { get; set; }

        /// <summary>
        ///  Team ID
        /// </summary>
        [JsonPropertyName("team_id")]
        public int TeamId { get; set; }

        /// <summary>
        /// Name of Team
        /// </summary>
        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }
    }
}