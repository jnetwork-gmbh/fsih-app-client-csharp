﻿using ch.jnetwork.fsih.api.client.client;
using ch.jnetwork.fsih.api.model;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client
{
    /// <summary>
    /// Client to Get Rankings
    /// </summary>
    public class RankingClient : IRankingClient
    {
        /// <summary>
        /// Get Ranking
        /// </summary>
        /// <param name="competitionId">Competition Id</param>
        /// <param name="seasonId">Season Id</param>
        /// <returns>Array of Ranking Objects</returns>
        public Ranking[] Get(int competitionId, int seasonId)
        {
            using (IRestClient client = new RestClient())
            {
                return client.Get<Ranking[]>($"/api/fsih_ranking/{competitionId}/{seasonId}");
            }
        }

        /// <summary>
        /// Get Ranking async
        /// </summary>
        /// <param name="competitionId">Competition Id</param>
        /// <param name="seasonId">Season Id</param>
        /// <returns>Task with Array of Ranking Objects</returns>
        public async Task<Ranking[]> GetAsync(int competitionId, int seasonId)
        {
            using (IRestClient client = new RestClient())
            {
                return await client.GetAsync<Ranking[]>($"/api/fsih_ranking/{competitionId}/{seasonId}");
            }
        }
    }
}