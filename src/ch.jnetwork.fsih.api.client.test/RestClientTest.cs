using ch.jnetwork.fsih.api.client.client;
using ch.jnetwork.fsih.api.dto;

namespace ch.jnetwork.fsih.api.client.test
{
    [TestClass]
    public class RestClientTest
    {
        [TestMethod]
        public void GetRankings()
        {
            RestClient client = new RestClient();

            Ranking[] task = client.GetRanking(27, 12).Result;

            Assert.AreNotEqual(0, task.Length);
            Assert.IsNotNull(task[0]);
            Assert.IsNotNull(task[0].TeamName);
            Assert.IsNotNull(task[0].RankingDetails);
            Assert.IsNotNull(task[0].RankingDetails.Points);
        }
    }
}
