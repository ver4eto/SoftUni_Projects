namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2);
        }

        [Test]
        public void Creating_DatabaseCount_ShouldBe_Correct()
        {
            //Arrange
            int expectedresult = 2;
            //Act
            //Database database = new Database(1, 2);
           
            int actualresult = database.Count;
            //Assert
            Assert.NotNull(database);
            Assert.AreEqual(expectedresult, actualresult);
        }
        [TestCase(new int[] { 1,2,3,4,5,6,7,8})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Create_Database_ShouldAddElements_Correctly(int[] data)
        {
            //act
            database = new (data);
            int []actualresult = database.Fetch();
            //assert
            Assert.AreEqual(data,actualresult);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void Create_Database_ShouldThrow_Exception_WhenCount_IsMoreThanSixteen(int[] data)
        {
            //act

            //assert
           InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                ()=> database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!",ex.Message);

        }

        [Test]
        public void Database_ShouldWork_Correctly()
        {
            int expectedResult = 2;
            int actualResult = database.Count;
            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestCase(-3)]
        [TestCase(0)]
        public void Database_AddMethod_ShouldIncrease_Count(int number)
        {
            //act
            int expectedResult = 3;
            database.Add(number);
            int actualresult = database.Count;
            //assert
            Assert.AreEqual(expectedResult,actualresult);

        }

        [TestCase(new int[] { 1,2,4,5,6,7,9})]
        public void DatabaseAddMethod_ShouldAddElementsCorrectly(int[] data)
        {
            database=new Database();

            foreach (int number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();
            Assert.AreEqual(data,actualResult);
        }
        [Test]       
        public void DatabaseAddMethod_ShouldThrow_Exception_WhenCount_IsMoreThanSixteen
            ()
        {
            //act
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }
            //assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                 () => database.Add(4456));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);

        }

        [Test]
        public void DatabaseRemoveMethod_ShouldDecrease_Count()
        {
            int expectedResult = 1;
            database.Remove();
            Assert.AreEqual(expectedResult,database.Count);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldRemove_Elements_Correctly()
        {
            int [] expectedResult = { };
            database.Remove();
            database.Remove();

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseRemoveMethod_ShouldThrow_Exception_When_Database_IsEmpty
            ()
        {
            //act
            database = new();
            
            //assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                 () => database.Remove());

            Assert.AreEqual("The collection is empty!", ex.Message);

        }

        [TestCase(new int[] { 1, 2, 4, 5, 6 })]
        public void DatabaseFetchMethod_ShouldReturnsElementsCorrectly(int[] data)
        {
            database = new Database(data);


            int[] actualResult = database.Fetch();
            Assert.AreEqual(data, actualResult);
        }
    }
}
