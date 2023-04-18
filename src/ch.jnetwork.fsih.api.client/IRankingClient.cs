using ch.jnetwork.fsih.api.model;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client
{
    public interface IRankingClient
    {
        Ranking[] Get(int competitionId, int seasonId);
        Task<Ranking[]> GetAsync(int competitionId, int seasonId);
    }
}