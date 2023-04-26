using ch.jnetwork.fsih.api.client.test.Faker;
using Moq;

namespace ch.jnetwork.fsih.api.client.test
{
    [TestClass]
    public class FsihAppApiTest
    {
        [TestMethod]
        public void CheckRankingPosition()
        {
            Mock<IRankingClient> rankingClientMock = new();

            rankingClientMock.Setup(x => x.Get(1, 1))
                .Returns(RankingFaker.GetRankings()
                .Generate(10)
                .ToArray());

            FsihAppApi fsihAppApi = new(rankingClientMock.Object, null);

            var result = fsihAppApi.GetRanking(1, 1);

            Assert.AreEqual(1, result[0].Position);
            Assert.AreEqual(result.Length, result[^1].Position);
            Assert.IsNotNull(result[0].GamesPlayed);
        }

        [TestMethod]
        public void CheckGameResult()
        {
            Mock<IGameClient> gameClientMock = new();

            gameClientMock.Setup(x => x.GetGames(1))
                .Returns(GameFaker.GetGames()
                .Generate(10)
                .ToArray());

            FsihAppApi fsihAppApi = new(null, gameClientMock.Object);

            var result = fsihAppApi.GetGames(1);

            Assert.IsNotNull(result[0].TeamHome);
            Assert.IsNotNull(result[0].TeamAway);
            Assert.IsNotNull(result[0].GamePlace);
            Assert.IsTrue(result[0].ScorePenalty.IndexOf(':') > 0);
        }


        [TestMethod]
        public void CheckGameResultByTeam()
        {
            Mock<IGameClient> gameClientMock = new();

            var gamesList = GameFaker.GetGames().Generate(10).ToArray();

            gameClientMock.Setup(x => x.GetGames(1))
                          .Returns(gamesList);

            FsihAppApi fsihAppApi = new(null, gameClientMock.Object);

            var teamIdFilter = gamesList.First().Team1Id;

            var result = fsihAppApi.GetGames(1, teamIdFilter);

            Assert.IsNotNull(result[0].TeamHome);
            Assert.IsNotNull(result[0].TeamAway);
            Assert.IsNotNull(result[0].GamePlace);
            Assert.IsTrue(result[0].ScorePenalty.IndexOf(':') > 0);
            Assert.IsTrue(result.Length >= 1);
        }
    }
}