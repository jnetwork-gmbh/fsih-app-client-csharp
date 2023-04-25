using ch.jnetwork.fsih.api.model;

namespace ch.jnetwork.fsih.api.client.test
{
    [TestClass]
    public class GamesClientTest
    {
        [TestMethod]
        public void GetGames()
        {
            GameClient client = new();

            Game[] result = client.Get(27);

            Assert.AreNotEqual(0, result.Length);
            Assert.IsNotNull(result[0]);
            Assert.IsNotNull(result[0].Code);
            Assert.IsNotNull(result[0].Team1);
            Assert.IsNotNull(result[0].Team1.Name);
            Assert.IsNotNull(result[0].Team2);
            Assert.IsNotNull(result[0].Team2.Name);
            Assert.AreEqual(2, result[0].Score.Count);
            Assert.AreEqual(6, result[0].Score.First().Value.Count);
        }

        [TestMethod]
        public void GetGamesAsync()
        {
            GameClient client = new();

            Game[] result = client.GetAsync(27).Result;

            Assert.AreNotEqual(0, result.Length);
            Assert.IsNotNull(result[0]);
            Assert.IsNotNull(result[0].Code);
            Assert.IsNotNull(result[0].Team1);
            Assert.IsNotNull(result[0].Team1.Name);
            Assert.IsNotNull(result[0].Team2);
            Assert.IsNotNull(result[0].Team2.Name);
            Assert.AreEqual(2, result[0].Score.Count);
            Assert.AreEqual(6, result[0].Score.First().Value.Count);
        }
    }
}