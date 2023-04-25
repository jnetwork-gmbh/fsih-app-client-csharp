using System;
using System.Text.Json.Serialization;

namespace ch.jnetwork.fsih.api.model
{
    public class Team
    {
        [JsonPropertyName("club2_id")]
        public int? Club2Id { get; set; }

        [JsonPropertyName("club3_id")]
        public object Club3Id { get; set; }

        [JsonPropertyName("club_id")]
        public int ClubId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("resp1_id")]
        public int Resp1Id { get; set; }

        [JsonPropertyName("resp2_id")]
        public int Resp2Id { get; set; }

        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}