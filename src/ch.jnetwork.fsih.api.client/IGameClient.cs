using ch.jnetwork.fsih.api.model;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client
{
    public interface IGameClient
    {
        GamePlace[] GetGameplaces();

        Task<GamePlace[]> GetGameplacesAsync();

        Game[] GetGames(int competitionId, int saisonId);

        Task<Game[]> GetGamesAsync(int competitionId, int saisonId);
    }
}