using ch.jnetwork.fsih.api.client.client;
using ch.jnetwork.fsih.api.model;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client
{
    /// <summary>
    /// Client to get games
    /// </summary>
    public class GameClient : IGameClient
    {
        /// <summary>
        /// Get Gameplan
        /// </summary>
        /// <param name="competitionId">Competition ID</param>
        /// <returns>Array of Games</returns>
        public Game[] Get(int competitionId)
        {
            using (IRestClient client = new RestClient())
            {
                return client.Get<Game[]>($"/api/fsih_game?competition_id={competitionId}");
            }
        }

        /// <summary>
        /// Get Gameplan async
        /// </summary>
        /// <param name="competitionId">Competition ID</param>
        /// <returns>Array of Games</returns>
        public async Task<Game[]> GetAsync(int competitionId)
        {
            using (IRestClient client = new RestClient())
            {
                return await client.GetAsync<Game[]>($"/api/fsih_game?competition_id={competitionId}");
            }
        }
    }
}