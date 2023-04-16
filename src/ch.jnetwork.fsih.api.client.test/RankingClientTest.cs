using ch.jnetwork.fsih.api.dto;

namespace ch.jnetwork.fsih.api.client.test
{
    [TestClass]
    public class RankingClientTest
    {
        [TestMethod]
        public void GetRankings()
        {
            RankingClient client = new RankingClient();

            Ranking[] result = client.Get(27, 12);

            Assert.AreNotEqual(0, result.Length);
            Assert.IsNotNull(result[0]);
            Assert.IsNotNull(result[0].TeamName);
            Assert.IsNotNull(result[0].RankingDetails);
            Assert.IsNotNull(result[0].RankingDetails.Points);
        }

        [TestMethod]
        public void GetRankingsAsync()
        {
            RankingClient client = new RankingClient();

            Ranking[] result = client.GetAsync(27, 12).Result;

            Assert.AreNotEqual(0, result.Length);
            Assert.IsNotNull(result[0]);
            Assert.IsNotNull(result[0].TeamName);
            Assert.IsNotNull(result[0].RankingDetails);
            Assert.IsNotNull(result[0].RankingDetails.Points);
        }
    }
}