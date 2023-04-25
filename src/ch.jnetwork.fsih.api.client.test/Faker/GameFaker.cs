using Bogus;
using ch.jnetwork.fsih.api.model;

namespace ch.jnetwork.fsih.api.client.test.Faker
{
    internal class GameFaker
    {
        protected GameFaker()
        {
        }

        internal static Faker<Game> GetGames() => new Faker<Game>()
            .RuleFor(x => x.DateTimeGame, f => f.Date.Recent())
            .RuleFor(x => x.Team1, f => GetTeam().Generate())
            .RuleFor(x => x.Team1Id, (f, itm) => itm.Team1.Id)
            .RuleFor(x => x.Team2, f => GetTeam().Generate())
            .RuleFor(x => x.Team2Id, (f, itm) => itm.Team2.Id)
            .RuleFor(x => x.DateTimeGame, f => f.Date.Recent())
            .RuleFor(x => x.Score, (f, itm) => new Dictionary<int, List<int>>
                {
                    { itm.Team1Id, new List<int>
                    {
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10)
                    } },
                    { itm.Team2Id, new List<int>
                    {
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10),
                        f.Random.Number(0, 10)
                    } }
                });

        internal static Faker<Team> GetTeam() => new Faker<Team>()
            .RuleFor(x => x.Id, f => f.UniqueIndex)
            .RuleFor(x => x.Name, f => f.Company.CompanyName());
    }
}