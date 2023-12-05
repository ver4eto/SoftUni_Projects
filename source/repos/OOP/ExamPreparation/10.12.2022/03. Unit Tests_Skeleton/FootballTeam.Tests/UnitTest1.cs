using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;
        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("Arda",19);
        }

        [Test]
        public void TestConstructor()
        {
           Assert.IsNotNull(team);
            Assert.AreEqual("Arda", team.Name);
            Assert.AreEqual(19, team.Capacity);
            Assert.AreEqual(0, team.Players.Count);
        }

        [Test]
        public void Test_ThrowsException_WhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam( null, 20)) ;
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 20));

        }

        [Test]
        public void Test_ThrowsException_When_CapacityIsLessThan15()
        {
           Exception exx = Assert.Throws<ArgumentException>(() => new FootballTeam("Sgo", 0));
            
            Assert.AreEqual(exx.Message, "Capacity min value = 15");
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 14));

        }

        [Test]
        public void TestAddNewPlayerWorksCorrectly()
        {
            var player = new FootballPlayer("Ivanov",2, "Goalkeeper");
           var result = team.AddNewPlayer(player);
            Assert.AreEqual(1, team.Players.Count);
            Assert.AreEqual(result, "Added player Ivanov in position Goalkeeper with number 2");

        }

        [Test]
        public void TestAddNewPlayerThrowsException()
        {
            for (int i = 1; i <= 19; i++)
            {
            var player = new FootballPlayer($"Pesho{i}", i, $"Goalkeeper");
            team.AddNewPlayer(player);
            }
            var expected = team.AddNewPlayer(new FootballPlayer("ivan", 20, "Midfielder"));
            Assert.AreEqual("No more positions available!",expected);
        }
        [Test]
        public void TestPickPlayerWorksCOrrectly()
        {
            var footballerToAdd = new FootballPlayer("Stamov", 12, "Goalkeeper");
            team.AddNewPlayer(footballerToAdd);
            var currentPlayer = team.PickPlayer("Stamov");
            Assert.AreEqual(footballerToAdd,currentPlayer);
        }

        [Test]
        public void TestPickPlayerReturnNull()
        {
            var footballerToAdd = new FootballPlayer("Stamov", 12, "Goalkeeper");
            team.AddNewPlayer(footballerToAdd);
            var currentPlayer = team.PickPlayer("KAGD");
            Assert.AreEqual(null, currentPlayer);
        }
        [Test]
        public void TestPlayerScoreWorksCorrectly()
        {
            var footballerToAdd = new FootballPlayer("Stamov", 12, "Goalkeeper");
            team.AddNewPlayer(footballerToAdd);
            footballerToAdd.Score();
            var result = team.PlayerScore(12);

            Assert.AreEqual(footballerToAdd.ScoredGoals,2);
            Assert.AreEqual(result, "Stamov scored and now has 2 for this season!");
        }
    }
}