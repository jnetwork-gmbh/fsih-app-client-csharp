using ch.jnetwork.fsih.api.model;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client
{
    public interface IGameClient
    {
        Game[] Get(int competitionId);

        Task<Game[]> GetAsync(int competitionId);
    }
}