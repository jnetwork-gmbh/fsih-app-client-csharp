namespace ch.jnetwork.fsih.api.dto
{
    /// <summary>
    /// Ranking
    /// </summary>
    public class RankingDto
    {
        /// <summary>
        /// Games played
        /// </summary>
        public int GamesPlayed { get; set; }

        /// <summary>
        /// Totals goals received
        /// </summary>
        public int GoalsReceive { get; set; }

        /// <summary>
        ///  Total goals scored
        /// </summary>
        public int GoalsScored { get; set; }

        /// <summary>
        /// Total games loose
        /// </summary>
        public int Loose { get; set; }

        /// <summary>
        /// Total games loose in overtime
        /// </summary>
        public int LooseOvertime { get; set; }

        /// <summary>
        /// Total games loose in penalty killing
        /// </summary>
        public int LoosePenalty { get; set; }

        /// <summary>
        /// Team Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Total points of team
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Ranking Position
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Total games win
        /// </summary>
        public int Win { get; set; }

        /// <summary>
        /// Total games win in overtime
        /// </summary>
        public int WinOvertime { get; set; }

        /// <summary>
        /// Total games win in penalty killing
        /// </summary>
        public int WinPenalty { get; set; }
    }
}