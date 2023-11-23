using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Axe_LoosesDurability_AfterAttck()
        {
            Axe axe = new Axe(10,10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints,Is.EqualTo(9),"Axe Durability doesn`t change after attack.");
        }
    }
}