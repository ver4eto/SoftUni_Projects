using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructorWorksProperly()
        {
            Hotel hotel = new Hotel("Nov hotel", 4);
            Assert.AreEqual("Nov hotel", hotel.FullName);
            Assert.AreEqual(4, hotel.Category);
            Assert.IsNotNull(hotel);
            Assert.IsNotNull(hotel.Bookings);
            Assert.IsNotNull(hotel.Rooms);
        }

        [Test]
        public void TestSetNameThrowException_WnehNameIsNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel("", 4));
            Assert.Throws<ArgumentNullException>(() => new Hotel(string.Empty, 4));
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 4));
        }

        [Test]
        public void TestCategoryThrowException_WhenCategoryIsLessThan1_OrMoreThan5()
        {
            Assert.Throws<ArgumentException>(() => new Hotel("HotelStar", 0));
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel zvezda", 6));
           
        }

        [Test]
        public void TestAddRoomWorksCorrectly()
        {
            Hotel hotel = new Hotel("Hotel star",3);
            Room room = new Room(2, 35);
            Room room2 = new Room(2, 45);
            Room room3 = new Room(4, 50);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.AreEqual(3, hotel.Rooms.Count);
        }

        [Test]
        public void TestRoomConstructor_WorksCorrectly()
        {
           // Hotel hotel = new Hotel("Hotel star", 3);
            Room room = new Room(2, 35);
            Room room2 = new Room(2, 45);
            Room room3 = new Room(4, 50);
            

            Assert.AreEqual(2, room.BedCapacity);
            Assert.AreEqual(35, room.PricePerNight);
            Assert.AreEqual(4, room3.BedCapacity);
            Assert.AreEqual(50, room3.PricePerNight);
            Assert.AreEqual(2, room2.BedCapacity);
            Assert.AreEqual(45, room2.PricePerNight);
        }

        [Test]
        public void TestBookRoom_WorksCorrectly()
        {
            Hotel hotel = new Hotel("Hotel star", 3);
            Room room = new Room(2, 35);
            Room room2 = new Room(2, 45);
            Room room3 = new Room(4, 50);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(4, 0, 2, 100);
            hotel.BookRoom(1, 1, 1, 45);

            Assert.AreEqual(3, hotel.Bookings.Count);
            Assert.AreEqual(180, hotel.Turnover);
        }
        [Test]
        public void TestBookRoom_ThrowsExceptionWhenAdultsAndChildrenAreBelow0()
        {
            Hotel hotel = new Hotel("Hotel star", 3);
            Room room = new Room(2, 35);
            Room room2 = new Room(2, 45);
            Room room3 = new Room(4, 50);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 2, 100));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 1, 45));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 0, -1, 45));

        }
        [Test]
        public void TestBookRoom_WorksProperly_WhenNotEnoughtBudget()
        {
            Hotel hotel = new Hotel("Hotel star", 3);
            Room room = new Room(2, 35);
            Room room2 = new Room(2, 45);
            Room room3 = new Room(4, 50);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(2, 0, 1, 15);
            Assert.AreEqual(0,hotel.Bookings.Count);
        }

        [Test]
        public void TestRoomCapacity_ThrowExceptionWhenBelow0()
        {

            Assert.Throws<ArgumentException>(() => new Room(0, 35));
            Assert.Throws<ArgumentException>(() => new Room(-14, 45));
            Assert.Throws<ArgumentException>(() => new Room(-45, 50));
        }

        [Test]
        public void TestRoomPricePerNight_ThrowExceptionWhenBelow0()
        {

            Assert.Throws<ArgumentException>(() => new Room(2, 0));
            Assert.Throws<ArgumentException>(() => new Room(3, -5));
            Assert.Throws<ArgumentException>(() => new Room(6, -50));
        }
    }
}
