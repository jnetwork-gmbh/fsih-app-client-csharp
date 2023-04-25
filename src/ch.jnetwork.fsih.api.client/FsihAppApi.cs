﻿using ch.jnetwork.fsih.api.dto;
using System.Linq;

namespace ch.jnetwork.fsih.api.client
{
    /// <summary>
    /// API of FSIH APP
    /// </summary>
    public class FsihAppApi
    {
        private readonly IGameClient gameClient;
        private readonly IRankingClient rankingClient;

        /// <summary>
        /// Constructor
        /// </summary>
        public FsihAppApi() : this(new RankingClient(),
                                   new GameClient())
        {
        }

        /// <summary>
        /// Internal Constructor
        /// </summary>
        /// <param name="rankingClient">Client for getting ranking</param>
        internal FsihAppApi(IRankingClient rankingClient, IGameClient gameClient)
        {
            this.rankingClient = rankingClient;
            this.gameClient = gameClient;
        }

        /// <summary>
        /// Get Games for competition
        /// </summary>
        /// <param name="competitionid">competition id</param>
        /// <returns>Array of all Games for competition </returns>
        public GameDto[] GetGames(int competitionid)
        {
            GameDto[] result = gameClient.Get(competitionid)
                          .Select(x => new GameDto()
                          {
                              Date = x.DateTimeGame,
                              GamePlay = "",
                              TeamHome = x.Team1.Name,
                              TeamAway = x.Team2.Name,
                              ScoreP1 = $"{x.Score[x.Team1Id][1]}:{x.Score[x.Team2Id][1]}",
                              ScoreP2 = $"{x.Score[x.Team1Id][2]}:{x.Score[x.Team2Id][2]}",
                              ScoreP3 = $"{x.Score[x.Team1Id][3]}:{x.Score[x.Team2Id][3]}",
                              ScoreOvertime = $"{x.Score[x.Team1Id][4]}:{x.Score[x.Team2Id][4]}",
                              ScorePenalty = $"{x.Score[x.Team1Id][5]}:{x.Score[x.Team2Id][5]}",
                              Score = $"{x.Score[x.Team1Id][0]}:{x.Score[x.Team2Id][0]}",
                          })
                          .ToArray();

            return result;
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