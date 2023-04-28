using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ch.jnetwork.fsih.api.model
{
    public class CompetitionType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("titles")]
        public List<CompetitionTitle> Titles { get; set; }
    }
}