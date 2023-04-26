using System;

namespace ch.jnetwork.fsih.api.dto
{
    public class GameDto
    {
        public DateTime Date { get; set; }
        public string GamePlace { get; set; }
        public bool HasGameDetails { get; set; }

        public bool HasOvertime
        {
            get
            {
                return ScoreOvertime != "0:0" && !HasPenalty;
            }
        }

        public bool HasPenalty
        {
            get
            {
                return ScorePenalty != "0:0";
            }
        }

        public string Score { get; set; }
        public string ScoreOvertime { get; set; }
        public string ScoreP1 { get; set; }
        public string ScoreP2 { get; set; }
        public string ScoreP3 { get; set; }
        public string ScorePenalty { get; set; }
        public string TeamAway { get; set; }
        public string TeamHome { get; set; }
    }
}