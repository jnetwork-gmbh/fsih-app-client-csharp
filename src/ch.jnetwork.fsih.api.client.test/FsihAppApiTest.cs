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

            FsihAppApi fsihAppApi = new(rankingClientMock.Object);

            var result = fsihAppApi.GetRanking(1, 1);

            Assert.AreEqual(1, result[0].Position);
            Assert.AreEqual(result.Length, result[^1].Position);
            Assert.IsNotNull(result[0].GamesPlayed);
        }
    }
}