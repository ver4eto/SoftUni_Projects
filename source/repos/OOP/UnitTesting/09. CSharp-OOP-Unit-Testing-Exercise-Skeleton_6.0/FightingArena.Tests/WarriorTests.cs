namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        //[SetUp]

        [Test]
        public void WarriorConstructor_ShouldWork_Correctly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 15;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.NotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedHP, warrior.HP);
            Assert.AreEqual(expectedDamage, warrior.Damage);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase("     ")]
        public void WarriorConstructorShouldThrow_ExceptionWhenNameIsEmptyWhitespaceAndStringEmpty(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()=>new Warrior(name, 25,200));

            Assert.AreEqual("Name should not be empty or whitespace!",ex.Message);
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
       
        public void WarriorConstructorShouldThrow_ExceptionWhenDamageIsLessThan0(int damage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Warrior("Stefan", damage, 200));

            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        
        [TestCase(-1)]
        [TestCase(-20)]
        public void WarriorConstructorShouldThrow_ExceptionWhenHPIsNegative(int hp)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Warrior("Stefan", 5, hp));

            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        public void AttackMethodShould_WorkCorrectly()
        {
            int expectedAttackerHP = 95;
            int expectedDefenderHP = 80;

            Warrior attacker = new Warrior("Ivan", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [TestCase(29)]
        [TestCase(30)]
        [TestCase(5)]
        public void WarriorShouldNotAttack_IfItsHPIsEqual_OrLessThan30(int hp)
        {

            Warrior attacker = new Warrior("Ivan", 10, hp);
            Warrior defender = new Warrior("Gosho", 5, 90);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [TestCase(29)]
        [TestCase(30)]
        [TestCase(5)]
        public void DefenderShouldNotAttack_IfItsHPIsEqual_OrLessThan30(int hp)
        {

            Warrior attacker = new Warrior("Ivan", 10, hp);
            Warrior defender = new Warrior("Gosho", 5, 90);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => defender.Attack(attacker));
            Assert.AreEqual($"Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        //[TestCase(29)]
        //[TestCase(30)]
        [Test]
        public void WariorShouldNotAttack_IfHisEnemyHPIsBiggerThat_HisHealth()
        {

            Warrior attacker = new Warrior("Ivan", 10, 35);
            Warrior defender = new Warrior("Gosho", 45, 90);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void AttackeMethod_EnemyHP_ShouldBeSetTo0_IfWarriorDamage_IsGreaterThanHisHP()
        {

            Warrior attacker = new Warrior("Ivan", 50, 100);
            Warrior defender = new Warrior("Gosho", 45, 40);

            attacker.Attack(defender);

            int expectedAttackerHP = 55;
            int expectedDefenderHP = 0;

            Assert.AreEqual(expectedAttackerHP,attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);

        }
    }
}