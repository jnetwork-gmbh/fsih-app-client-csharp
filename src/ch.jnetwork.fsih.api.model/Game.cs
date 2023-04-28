using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ch.jnetwork.fsih.api.model
{
    public class Game
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("comment")]
        public object Comment { get; set; }

        [JsonPropertyName("competition")]
        public Competition Competition { get; set; }

        [JsonPropertyName("competition_id")]
        public int CompetitionId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("date_time")]
        public string DateTime { get; set; }

        [JsonPropertyName("date_time_game")]
        public DateTime DateTimeGame { get; set; }

        [JsonPropertyName("date_time_original")]
        public DateTime DateTimeOriginal { get; set; }

        [JsonPropertyName("dateTimeRFC")]
        public DateTime DateTimeRFC { get; set; }

        [JsonPropertyName("game_place_id")]
        public int GamePlaceId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("livestreaming")]
        public object Livestreaming { get; set; }

        [JsonPropertyName("livestreaming_url")]
        public object LivestreamingUrl { get; set; }

        [JsonPropertyName("nb_spectators")]
        public int? NbSpectators { get; set; }

        [JsonPropertyName("points_team1")]
        public int? PointsTeam1 { get; set; }

        [JsonPropertyName("points_team2")]
        public int? PointsTeam2 { get; set; }

        [JsonPropertyName("request_date_time")]
        public object RequestDateTime { get; set; }

        [JsonPropertyName("request_state")]
        public object RequestState { get; set; }

        [JsonPropertyName("round")]
        public int Round { get; set; }

        [JsonPropertyName("score")]
        public Dictionary<int, List<int>> Score { get; set; }

        [JsonPropertyName("score_team1")]
        public int? ScoreTeam1 { get; set; }

        [JsonPropertyName("score_team2")]
        public int? ScoreTeam2 { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }

        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        [JsonPropertyName("state")]
        public int State { get; set; }

        [JsonPropertyName("team1")]
        public Team Team1 { get; set; }

        [JsonPropertyName("team1_id")]
        public int Team1Id { get; set; }

        [JsonPropertyName("team2")]
        public Team Team2 { get; set; }

        [JsonPropertyName("team2_id")]
        public int Team2Id { get; set; }

        [JsonPropertyName("time_start")]
        public string TimeStart { get; set; }

        [JsonPropertyName("time_stop")]
        public string TimeStop { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("winner_id")]
        public int? WinnerId { get; set; }
    }
}