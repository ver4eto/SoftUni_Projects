using NUnit.Framework;
using System.Runtime.Intrinsics.X86;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFactoryConstructor_Works_Properly()
        {
            Factory factory = new Factory("Myfactory", 10);
            Assert.IsNotNull(factory);
            Assert.AreEqual(factory.Name, "Myfactory");
            Assert.AreEqual(factory.Capacity, 10);
            Assert.IsNotNull(factory.Supplements);
            Assert.IsNotNull(factory.Robots);
           
        }

        [Test]
        public void TestProduceRobot_WorksProperly()
        {
            string model = "model"; double price = 10; int interfaceStandard = 1045;
            //Robot robot=new Robot(model, price, interfaceStandard);
            Factory factory = new Factory("myfactory",10);
            string result = factory.ProduceRobot(model, price, interfaceStandard);
            Assert.IsNotNull(result);
            
            Assert.AreEqual(1,factory.Robots.Count);
            Assert.AreEqual("Produced --> Robot model: model IS: 1045, Price: 10.00", result);
            
        }
        [Test]
        public void TestProduceRobot_ReturnFalse_MoreThanCapacity()
        {
            string model = "model"; double price = 10; int interfaceStandard = 1045;
            //Robot robot=new Robot(model, price, interfaceStandard);
            Factory factory = new Factory("myfactory", 1);
            factory.ProduceRobot(model,price,interfaceStandard);
            string result = factory.ProduceRobot(model, price, interfaceStandard);

            Assert.AreEqual("The factory is unable to produce more robots for this production day!",result);

        }

        [Test]
        public void TestProduceSupplement_WorksCorrectly()
        {
           
            Factory factory = new Factory("myfactory", 10);
            
          string result=  factory.ProduceSupplement("supplement", 1001);
           
            Assert.AreEqual(1,factory.Supplements.Count);
            Assert.AreEqual("Supplement: supplement IS: 1001",result);
        }
        [Test]
        public void TestUprgradeRobot_WorksCorrectly()
        {
            Supplement supplement = new Supplement("supplement", 1005);
            Robot robot = new Robot("model",12.50,1005);
            Factory factory = new Factory("myfactory", 10);

            //factory.Robots.Add(robot);
           bool result = factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(robot.Price, 12.50);
            Assert.AreEqual(robot.Model, "model");
      Assert.AreEqual(1,robot.Supplements.Count);
            Assert.IsTrue(result);

        }

        [Test]
        public void TestUprgradeRobot_WhenRobotContainsSupplement()
        {
            Supplement supplement = new Supplement("supplement", 1005);
            Robot robot = new Robot("model", 12.50, 1005);
            Factory factory = new Factory("myfactory", 10);

            factory.UpgradeRobot(robot, supplement);
            bool result = factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(robot.Price, 12.50);
            Assert.AreEqual(robot.Model, "model");
            Assert.AreEqual(1, robot.Supplements.Count);
            Assert.AreEqual(1005, robot.InterfaceStandard);
            Assert.IsFalse(result);

        }
        [Test]
        public void TestUprgradeRobot_WhenAddingDifferentInterfaceStandart()
        {
            Supplement supplement = new Supplement("supplement", 100);
            Robot robot = new Robot("model", 12.50, 1005);
            Factory factory = new Factory("myfactory", 10);

            
            bool result = factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(robot.Price, 12.50);
            Assert.AreEqual(robot.Model, "model");
            Assert.AreEqual(0, robot.Supplements.Count);
            Assert.IsFalse(result);

        }

        [Test]
        public void TestConstructor_Supplement_WorksCorrectly()
        {
            Supplement supplement = new Supplement("supplement", 100);
            

            Assert.AreEqual("supplement", supplement.Name);
            Assert.AreEqual(100, supplement.InterfaceStandard);

            Assert.IsNotNull(supplement);

        }

        [Test]
        public void TestSellRobot_WorksCorrectly()
        {
            
           // Robot robot = new Robot("model", 12.50, 1005);
            Factory factory = new Factory("myfactory", 10);
            factory.ProduceRobot("model", 12.50, 1005);
            factory.ProduceRobot("model2", 32, 100);
            factory.ProduceRobot("model3", 2.50, 2205);
            factory.ProduceRobot("model4", 32, 340);

           Robot robot= factory.SellRobot(5);
            Assert.AreEqual(2.50, robot.Price);
            Assert.AreEqual("model3", robot.Model);
            Assert.AreEqual(2205, robot.InterfaceStandard);
            Assert.IsNotNull (robot);

        }

        [Test]
        public void TestSellRobot_ReturnsNull_WhenNoSuchRobot_Exist()
        {

            // Robot robot = new Robot("model", 12.50, 1005);
            Factory factory = new Factory("myfactory", 10);
            factory.ProduceRobot("model", 12.50, 1005);
            

            Robot robot = factory.SellRobot(5);
            
            Assert.Null(robot);

        }
    }
}