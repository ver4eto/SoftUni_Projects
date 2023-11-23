namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();

        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }


        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 1;
            Warrior warrior = new Warrior("Gosho", 5,100);
            arena.Enroll(warrior);
            Assert.IsNotNull (arena.Warriors);
            Assert.AreEqual(expectedResult, arena.Warriors.Count);
        }

        [Test]
        public void ArenaEnrollMethodShouldWorkCorrectly()
        {
            //int expectedResult = 1;
            Warrior warrior = new Warrior("Gosho", 5, 100);
            arena.Enroll(warrior);
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        
        public void ArenaEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {

            Warrior warrior = new Warrior("Ivan", 10, 100);

         arena.Enroll(warrior);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
            
            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void FightMethodIsWorkingCorrectly()
        {
            Warrior firstWarrior=new Warrior("Gosho", 15,100);
            Warrior secondWarrior = new Warrior("Pesho", 5, 50);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            int expectedFirstHP = 95;
            int expectedSecondHP = 35;

            arena.Fight(firstWarrior.Name, secondWarrior.Name);

            Assert.AreEqual(expectedFirstHP, firstWarrior.HP);
            Assert.AreEqual(expectedSecondHP, secondWarrior.HP);
        }

        [Test]

        public void ArenaFightShouldThrowExceptionIfDefenderIsNotFound()
        {

            Warrior attacker = new Warrior("Gosho", 15, 100);
            Warrior defender = new Warrior("Pesho", 5, 50);

            arena.Enroll(attacker);

            
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name,defender.Name));

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }

        public void ArenaFightShouldThrowExceptionIfAttackerIsNotFound()
        {

            Warrior attacker = new Warrior("Gosho", 15, 100);
            Warrior defender = new Warrior("Pesho", 5, 50);

            arena.Enroll(defender);


            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }
    }
}
