using ch.jnetwork.fsih.api.dto;
using System.Linq;

namespace ch.jnetwork.fsih.api.client
{
    /// <summary>
    /// API of FSIH APP
    /// </summary>
    public class FsihAppApi
    {
        private readonly IRankingClient rankingClient;

        /// <summary>
        /// Constructor
        /// </summary>
        public FsihAppApi() : this(new RankingClient())
        {
        }

        /// <summary>
        /// Internal Constructor
        /// </summary>
        /// <param name="rankingClient">Client for getting ranking</param>
        internal FsihAppApi(IRankingClient rankingClient)
        {
            this.rankingClient = rankingClient;
        }

        public RankingDto[] GetRanking(int competitionid, int seasonid)
        {
            RankingDto[] result = rankingClient.Get(competitionid, seasonid)
                .Select(x => new RankingDto()
                {
                    GamesPlayed = x.RankingDetails.GamesPlayed,
                    GoalsReceive = x.RankingDetails.GoalsReceive,
                    GoalsScored = x.RankingDetails.GoalsScored,
                    Loose = x.RankingDetails.Loose,
                    LooseOvertime = x.RankingDetails.LooseOvertime,
                    LoosePenalty = x.RankingDetails.LoosePenalty,
                    Name = x.TeamName,
                    Points = x.RankingDetails.Points,
                    Position = 0,
                    Win = x.RankingDetails.Win,
                    WinOvertime = x.RankingDetails.WinOvertime,
                    WinPenalty = x.RankingDetails.WinPenalty
                })
                .ToArray();

            // set position
            for (int i = 0; i < result.Count(); i++)
                result.ElementAt(i).Position = i + 1;

            return result;
        }
    }
}