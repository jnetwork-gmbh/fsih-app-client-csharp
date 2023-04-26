using ch.jnetwork.fsih.api.client.test.Faker;
using ch.jnetwork.fsih.api.dto;
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
        public void CheckGameResult_WithGameDetails()
        {
            Mock<IGameClient> gameClientMock = new();

            gameClientMock.Setup(x => x.GetGames(1))
                .Returns(GameFaker.GetGames(true)
                .Generate(10)
                .ToArray());

            FsihAppApi fsihAppApi = new(null, gameClientMock.Object);

            var result = fsihAppApi.GetGames(1);

            Assert.IsNotNull(result[0].TeamHome);
            Assert.IsNotNull(result[0].TeamAway);
            Assert.IsNotNull(result[0].GamePlace);
            Assert.IsTrue(result[0].HasGameDetails);
            Assert.IsTrue(result[0].ScorePenalty.Contains(':'));
            Assert.IsFalse(result[0].ScorePenalty.StartsWith(':'));
            Assert.IsFalse(result[0].ScorePenalty.EndsWith(':'));
        }

        [TestMethod]
        public void CheckGameResultByTeam_WithGameDetails()
        {
            Mock<IGameClient> gameClientMock = new();

            var gamesList = GameFaker.GetGames(true).Generate(10).ToArray();

            gameClientMock.Setup(x => x.GetGames(1))
                          .Returns(gamesList);

            FsihAppApi fsihAppApi = new(null, gameClientMock.Object);

            var teamIdFilter = gamesList.First().Team1Id;

            var result = fsihAppApi.GetGames(1, teamIdFilter);

            Assert.IsNotNull(result[0].TeamHome);
            Assert.IsNotNull(result[0].TeamAway);
            Assert.IsNotNull(result[0].GamePlace);
            Assert.IsTrue(result[0].HasGameDetails);
            Assert.IsTrue(result[0].ScorePenalty.Contains(':'));
            Assert.IsFalse(result[0].ScorePenalty.StartsWith(':'));
            Assert.IsFalse(result[0].ScorePenalty.EndsWith(':'));
            Assert.IsTrue(result.Length >= 1);
        }

        [TestMethod]
        public void CheckGameResult_WithoutGameDetails()
        {
            Mock<IGameClient> gameClientMock = new();

            gameClientMock.Setup(x => x.GetGames(1))
                .Returns(GameFaker.GetGames(false)
                .Generate(10)
                .ToArray());

            FsihAppApi fsihAppApi = new(null, gameClientMock.Object);

            var result = fsihAppApi.GetGames(1);

            Assert.IsNotNull(result[0].TeamHome);
            Assert.IsNotNull(result[0].TeamAway);
            Assert.IsNotNull(result[0].GamePlace);
            Assert.IsFalse(result[0].HasGameDetails);
            Assert.IsTrue(result[0].ScorePenalty.Contains(':'));
            Assert.IsFalse(result[0].ScorePenalty.StartsWith(':'));
            Assert.IsFalse(result[0].ScorePenalty.EndsWith(':'));
        }

        [TestMethod]
        public void CheckGameResultByTeam_WithoutGameDetails()
        {
            Mock<IGameClient> gameClientMock = new();

            var gamesList = GameFaker.GetGames(false).Generate(10).ToArray();

            gameClientMock.Setup(x => x.GetGames(1))
                          .Returns(gamesList);

            FsihAppApi fsihAppApi = new(null, gameClientMock.Object);

            var teamIdFilter = gamesList.First().Team1Id;

            var result = fsihAppApi.GetGames(1, teamIdFilter);

            Assert.IsNotNull(result[0].TeamHome);
            Assert.IsNotNull(result[0].TeamAway);
            Assert.IsNotNull(result[0].GamePlace);
            Assert.IsFalse(result[0].HasGameDetails);
            Assert.IsTrue(result[0].ScorePenalty.Contains(':'));
            Assert.IsFalse(result[0].ScorePenalty.StartsWith(':'));
            Assert.IsFalse(result[0].ScorePenalty.EndsWith(':'));
            Assert.IsTrue(result.Length >= 1);
        }

        [TestMethod]
        public void ValidateHasOvertime()
        {
            GameDto dto;

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "0:0",
                ScorePenalty = "0:0"
            };

            Assert.IsFalse(dto.HasOvertime);

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "1:0",
                ScorePenalty = "0:0"
            };

            Assert.IsTrue(dto.HasOvertime);

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "1:0",
                ScorePenalty = "1:0"
            };

            Assert.IsFalse(dto.HasOvertime);

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "0:0",
                ScorePenalty = "1:0"
            };

            Assert.IsFalse(dto.HasOvertime);
        }

        [TestMethod]
        public void ValidateHasPenalty()
        {
            GameDto dto;

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "0:0",
                ScorePenalty = "0:0"
            };

            Assert.IsFalse(dto.HasPenalty);

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "1:0",
                ScorePenalty = "0:0"
            };

            Assert.IsFalse(dto.HasPenalty);

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "1:0",
                ScorePenalty = "1:0"
            };

            Assert.IsTrue(dto.HasPenalty);

            dto = new GameDto()
            {
                ScoreP1 = "0:0",
                ScoreP2 = "0:0",
                ScoreP3 = "0:0",
                ScoreOvertime = "0:0",
                ScorePenalty = "1:0"
            };

            Assert.IsTrue(dto.HasPenalty);
        }
    }
}