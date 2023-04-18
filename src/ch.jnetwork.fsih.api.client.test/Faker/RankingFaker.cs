using Bogus;
using ch.jnetwork.fsih.api.model;

namespace ch.jnetwork.fsih.api.client.test.Faker
{
    internal class RankingFaker
    {
        protected RankingFaker()
        {
        }

        internal static Faker<Ranking> GetRankings() => new Faker<Ranking>()
            .RuleFor(x => x.TeamId, f => f.UniqueIndex)
            .RuleFor(x => x.TeamName, f => f.Company.CompanyName())
            .RuleFor(x => x.RankingDetails, f => GetRankingDetail().Generate());

        internal static Faker<RankingDetail> GetRankingDetail() => new Faker<RankingDetail>()
            .RuleFor(x => x.GamesPlayed, f => f.Random.Number(0, 10))
            .RuleFor(x => x.GoalsReceive, f => f.Random.Number(0, 10))
            .RuleFor(x => x.GoalsScored, f => f.Random.Number(0, 10))
            .RuleFor(x => x.Loose, f => f.Random.Number(0, 10))
            .RuleFor(x => x.LooseOvertime, f => f.Random.Number(0, 10))
            .RuleFor(x => x.LoosePenalty, f => f.Random.Number(0, 10))
            .RuleFor(x => x.Points, f => f.Random.Number(0, 10))
            .RuleFor(x => x.Win, f => f.Random.Number(0, 10))
            .RuleFor(x => x.WinOvertime, f => f.Random.Number(0, 10))
            .RuleFor(x => x.WinPenalty, f => f.Random.Number(0, 10));
    }
}