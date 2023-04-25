using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ch.jnetwork.fsih.api.model
{
    public class Competition
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("competition_type")]
        public CompetitionType CompetitionType { get; set; }

        [JsonPropertyName("competition_type_id")]
        public int CompetitionTypeId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("displayRankings")]
        public int DisplayRankings { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("part1_duration")]
        public string Part1Duration { get; set; }

        [JsonPropertyName("part2_duration")]
        public string Part2Duration { get; set; }

        [JsonPropertyName("part3_duration")]
        public string Part3Duration { get; set; }

        [JsonPropertyName("part4_duration")]
        public string Part4Duration { get; set; }

        [JsonPropertyName("penalty")]
        public int Penalty { get; set; }

        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        [JsonPropertyName("titles")]
        public List<CompetitionTitle> Titles { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}