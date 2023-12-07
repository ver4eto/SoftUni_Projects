namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("IndianaJones", "VictorHugo", "Adventure");
            
        }

        [Test]
        public void TestConstructorWorks_Properly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("IndianaJones", "VictorHugo", "Adventure");
            Assert.IsNotNull(library);
            Assert.IsNotNull(library.Catalogue);
        }

        [Test]
        public void TestAddBook_Works_Properly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("IndianaJones", "VictorHugo", "Adventure");
          string result =  library.AddTextBookToLibrary(book);

            StringBuilder sb= new StringBuilder();
            sb.AppendLine("Book: IndianaJones - 1");
            sb.AppendLine("Category: Adventure");
            sb.AppendLine("Author: VictorHugo");
            Assert.AreEqual(1,library.Catalogue.Count);
            Assert.AreEqual(sb.ToString().TrimEnd(),result);
        }

        [Test]
        public void TestLoanTextBook_Works_Properly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("IndianaJones", "VictorHugo", "Adventure");
            TextBook book2 = new TextBook("Vinetu", "Duma", "Kids");
            TextBook book3 = new TextBook("Alice in wonderland", "DanielDefo", "Novel");
           library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);
            library.AddTextBookToLibrary(book3);

            string result = library.LoanTextBook(2, "Ivan");
            Assert.AreEqual("Vinetu loaned to Ivan.", result);
            string result2 = library.LoanTextBook(1, "Sava");
            Assert.AreEqual("IndianaJones loaned to Sava.", result2);

        }
        [Test]
        public void TestLoanTextBook_When_BookIsAlreadyLoaned()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("IndianaJones", "VictorHugo", "Adventure");
            TextBook book2 = new TextBook("Vinetu", "Duma", "Kids");
            TextBook book3 = new TextBook("Alice in wonderland", "DanielDefo", "Novel");
            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);
            library.AddTextBookToLibrary(book3);

            string result = library.LoanTextBook(2, "Ivan");
           
            string result2 = library.LoanTextBook(2, "Ivan");
            Assert.AreEqual("Ivan still hasn't returned Vinetu!", result2);
        }
        [Test]
        public void TestReturnTheBook_Works_Properly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("IndianaJones", "VictorHugo", "Adventure");
            TextBook book2 = new TextBook("Vinetu", "Duma", "Kids");
            TextBook book3 = new TextBook("Alice in wonderland", "DanielDefo", "Novel");
            library.AddTextBookToLibrary(book);
            library.AddTextBookToLibrary(book2);
            library.AddTextBookToLibrary(book3);

            library.LoanTextBook(2, "Ivan");
           
            string result2 = library.ReturnTextBook(2);
            Assert.AreEqual("Vinetu is returned to the library.", result2);
            Assert.AreEqual(3, library.Catalogue.Count);
            Assert.IsEmpty(book2.Holder);
        }
    }
}