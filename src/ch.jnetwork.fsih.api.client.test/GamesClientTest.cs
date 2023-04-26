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

            Game[] result = client.GetGames(27);

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

            Game[] result = client.GetGamesAsync(27).Result;

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
        public void GetGamePlaces()
        {
            GameClient client = new();

            GamePlace[] result = client.GetGameplaces();

            Assert.AreNotEqual(0, result.Length);
            Assert.IsNotNull(result[0]);
            Assert.IsNotNull(result[0].Code);
            Assert.IsNotNull(result[0].Name);
        }

        [TestMethod]
        public void GetGamePlacesAsync()
        {
            GameClient client = new();

            GamePlace[] result = client.GetGameplacesAsync().Result;

            Assert.AreNotEqual(0, result.Length);
            Assert.IsNotNull(result[0]);
            Assert.IsNotNull(result[0].Code);
            Assert.IsNotNull(result[0].Name);
        }
    }
}