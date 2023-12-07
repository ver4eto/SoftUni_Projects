using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestConstructor_Works_properly()
        {
            CoffeeMat mat = new CoffeeMat(10, 5);
            Assert.IsNotNull(mat);
            Assert.AreEqual(10, mat.WaterCapacity);
            Assert.AreEqual(5, mat.ButtonsCount);
            Assert.AreEqual(mat.Income, 0);
           // Assert.AreEqual(0,mat.)
        }

        [Test]
        public void TestFillWaterTank_Works_properly()
        {
            CoffeeMat mat = new CoffeeMat(10, 5);
            string result = mat.FillWaterTank();
           
            Assert.AreEqual("Water tank is filled with 10ml", result);
           
        }

        [Test]
        public void TestFillWaterTank_ThrowsException_WhenNoCapacityAvailable()
        {
            CoffeeMat mat = new CoffeeMat(10, 5);
            mat.FillWaterTank();
            string result = mat.FillWaterTank();
           
            Assert.AreEqual("Water tank is already full!", result);
        }

        [Test]
        public void Test_AddDrink_Works_properly()
        {
            CoffeeMat mat = new CoffeeMat(10, 5);
            bool result = mat.AddDrink("Cola",15.40);

            Assert.IsTrue( result);
        }

        [Test]
        public void Test_AddDrink_ReturnFalse_WhenNOCapacity()
        {
            CoffeeMat mat = new CoffeeMat(10, 3);
            mat.AddDrink("Coffee", 15.40);
            mat.AddDrink("Airan", 15.40);
            mat.AddDrink("Water", 15.40);
            bool result = mat.AddDrink("Cola", 15.40);

            Assert.IsFalse(result);
        }
        [Test]
        public void Test_AddDrink_ReturnFalse_WhenSameNameAdded()
        {
            CoffeeMat mat = new CoffeeMat(10, 3);
            mat.AddDrink("Coffee", 15.40);
           
            bool result = mat.AddDrink("Coffee", 15.40);
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_AddDrink_ReturnFalse_WhenDrinkCountIsBiggerTHankButtonsCount()
        {
            CoffeeMat mat = new CoffeeMat(10, 3);
            mat.AddDrink("Coffee", 15.40);
            mat.AddDrink("HotChocolate", 15.40);
            mat.AddDrink("Tea", 15);
            bool result = mat.AddDrink("Water", 15.40);
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_BuyDrink_Works_properly()
        {
            CoffeeMat mat = new CoffeeMat(100, 5);
            mat.FillWaterTank();
            mat.AddDrink("Cola", 15.40);

            string result = mat.BuyDrink("Cola");
            double income = mat.Income;
            Assert.AreEqual("Your bill is 15.40$",result);
            Assert.AreEqual(income, mat.Income);
        }

        [Test]
        public void Test_BuyDrink_ReturnMessage_WhenNoEnoughtWater()
        {
            CoffeeMat mat = new CoffeeMat(70, 5);
            mat.FillWaterTank();
            mat.AddDrink("Cola", 15.40);

            string result = mat.BuyDrink("Cola");
            double income = 0;
            Assert.AreEqual("CoffeeMat is out of water!", result);
            Assert.AreEqual(income, mat.Income);
        }
        [Test]
        public void Test_BuyDrink_ReturnMessage_WhenDrinkIsNotAvailable()
        {
            CoffeeMat mat = new CoffeeMat(100, 5);
            mat.FillWaterTank();
            mat.AddDrink("Soda", 15.40);

            string result = mat.BuyDrink("Cola");
            double income = 0;
            Assert.AreEqual("Cola is not available!", result);
            //Assert.AreEqual(income, mat.Income);
        }

        [Test]
        public void Test_CollectIncome_Works_properly()
        {
            CoffeeMat mat = new CoffeeMat(10000, 5);
            mat.FillWaterTank();
            
            mat.AddDrink("Cola", 5);
            mat.AddDrink("Kofe", 15);
            mat.AddDrink("Wine", 10);
            mat.BuyDrink("Cola");
            mat.BuyDrink("Cola");
            mat.BuyDrink("Wine");
            mat.BuyDrink("Wine");
            mat.BuyDrink("Kofe");

            double incomeBeforeCollecting = mat.Income;
            double result = mat.CollectIncome();
           double income = mat.Income;
            Assert.AreEqual(45, incomeBeforeCollecting);
           Assert.AreEqual(0,income);
            Assert.AreEqual(45, result);
        }
        [Test]
        public void CheckWaterConsuming()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Milk");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            string actualResult = coffeeMat.BuyDrink("Hot Chocolate");

            string expectedResult = "CoffeeMat is out of water!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        //[Test]
        //public void CollectIncome()
        //{
        //    CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

        //    coffeeMat.FillWaterTank();

        //    coffeeMat.AddDrink("Coffee", 0.80);
        //    coffeeMat.AddDrink("Macciato", 1.80);
        //    coffeeMat.AddDrink("Capuccino", 1.50);
        //    coffeeMat.AddDrink("Latte", 1.00);
        //    coffeeMat.AddDrink("Hot Chocolate", 1.60);
        //    coffeeMat.AddDrink("Milk", 0.90);
        //    coffeeMat.AddDrink("Tea", 0.60);
        //    coffeeMat.AddDrink("Hot Water", 0.30);

        //    coffeeMat.BuyDrink("Coffee");
        //    coffeeMat.BuyDrink("Macciato");
        //    coffeeMat.BuyDrink("Capuccino");
        //    coffeeMat.BuyDrink("Latte");
        //    coffeeMat.BuyDrink("Milk");
        //    coffeeMat.BuyDrink("Hot Chocolate");

        //    double actualIncome = coffeeMat.Income;
        //    double income = coffeeMat.CollectIncome();
        //    double incomeAfterCollecting = coffeeMat.Income;

        //    Assert.AreEqual((double)income, actualIncome);
        //    Assert.That(7.60, Is.EqualTo(income));
        //    Assert.That(0, Is.EqualTo(incomeAfterCollecting));
        //}
    }
}