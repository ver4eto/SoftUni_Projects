using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        
             
        [SetUp]
        public void Setup()
        {
      
        }

        [Test]
        public void ConstructorWorksProperly()
        {
            Garage garage = new Garage(10);
            Assert.AreEqual(10, garage.Capacity);
            Assert.IsNotNull(garage.Vehicles);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [Test]
        public void TestAddVehicleWorksProperly()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
           bool result = garage.AddVehicle(vehicle);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(true, result);
            Assert.Contains(vehicle,garage.Vehicles);
        }

        [Test]
        public void TestAddVehicle_ThrowException_When_CapacityIsFull()
        {
            Garage garage = new Garage(1);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
            garage.AddVehicle(vehicle);

            bool resulAddedExisting= garage.AddVehicle(vehicle);
            bool result = garage.AddVehicle(new Vehicle("Asd", "model", "12986"));
            Assert.AreEqual(false, resulAddedExisting);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void TestAddVehicle_ThrowException_When_PlateExists()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
            garage.AddVehicle(vehicle);

            bool resulAddedExisting = garage.AddVehicle(vehicle);
            
            Assert.IsFalse(garage.AddVehicle(vehicle));
           
        }

        [Test]
        public void TestChargeVehicleWorksProperly()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
            Vehicle vehicle2 = new Vehicle("Asd1", "models", "12233");
            Vehicle vehicle3 = new Vehicle("3Asd", "3model", "3467");
            Vehicle vehicle4 = new Vehicle("ZaAsd", "Kmodel", "346756");
            garage.AddVehicle(vehicle);
            vehicle.BatteryLevel = 1;
            garage.AddVehicle(vehicle2);
            vehicle2.BatteryLevel = 1;
            garage.AddVehicle(vehicle3);
            vehicle3.BatteryLevel = 1;
            garage.AddVehicle(vehicle4);
            vehicle4.BatteryLevel = 1;

            int countCharged = garage.ChargeVehicles(1);
            Assert.AreEqual(4,countCharged);
            Assert.AreEqual(100,vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
            Assert.AreEqual(100, vehicle3.BatteryLevel);
            Assert.AreEqual(100, vehicle4.BatteryLevel);

        }

        [Test]
        public void TestDriveVehicle_WorksCorrectly()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
            vehicle.BatteryLevel = 100;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("12234", 10, true);

            Assert.AreEqual(vehicle.BatteryLevel, 90);
            Assert.AreEqual(true, vehicle.IsDamaged);
        }
        [Test]
        public void Garage_DriveVehicle_AlreadyDamaged()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");
           

            garage.AddVehicle(car);
            

            garage.DriveVehicle("CT7006H", 50, true);
            garage.DriveVehicle("CT7006H", 50, true);

            int actualBaterryLevel = car.BatteryLevel;

            Assert.AreEqual(50,actualBaterryLevel);
        }

        [Test]
        public void Garage_DriveVehicle_BatteryDrainageMoreThan100()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");


            garage.AddVehicle(car);


            garage.DriveVehicle("CT7006H", 111, true);
            garage.DriveVehicle("CT7006H", 111, true);

            int actualBaterryLevel = car.BatteryLevel;

            Assert.AreEqual(100, actualBaterryLevel);
        }

        [Test]
        public void Garage_DriveVehicle_BatteryIsLessThanDrainage()
        {
            Garage garage = new Garage(5);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");


            garage.AddVehicle(car);


            garage.DriveVehicle("CT7006H", 70, false);
            garage.DriveVehicle("CT7006H", 70, false);

            int actualBaterryLevel = car.BatteryLevel;

            Assert.AreEqual(30, actualBaterryLevel);
        }
        [Test]
        public void TestRepairVehicle_WorksCorrectly()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
            Vehicle vehicle2 = new Vehicle("Asd1", "models", "12233");
            Vehicle vehicle3 = new Vehicle("3Asd", "3model", "3467");
            Vehicle vehicle4 = new Vehicle("ZaAsd", "Kmodel", "346756");
            garage.AddVehicle(vehicle);
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle2);
            vehicle2.IsDamaged = true;
            garage.AddVehicle(vehicle3);
            vehicle3.IsDamaged = true;
            garage.AddVehicle(vehicle4);
            vehicle4.IsDamaged = true;

            string countCharged = garage.RepairVehicles();
            Assert.AreEqual("Vehicles repaired: 4", countCharged);
            Assert.IsFalse(vehicle.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);
            Assert.IsFalse(vehicle4.IsDamaged);

        }

        [Test]
        public void TestVehicleBatteryLevvelSetterWorksCorrectly()
        {
            Vehicle vehicle4 = new Vehicle("ZaAsd", "Kmodel", "346756");
            vehicle4.BatteryLevel = 5;
            Assert.AreEqual(5, vehicle4.BatteryLevel);
        }

        [Test]
        public void TestIsDamageVehicleWorksCorrectly()
        {
            Vehicle vehicle4 = new Vehicle("ZaAsd", "Kmodel", "346756");
            vehicle4.IsDamaged = true;
            Assert.AreEqual(true, vehicle4.IsDamaged);
        }

        [Test]
        public void TestLicencePlateWorksCorrectly()
        {
            Vehicle vehicle4 = new Vehicle("ZaAsd", "Kmodel", "346756");
            vehicle4.LicensePlateNumber = "new plate";
            
            Assert.AreEqual("new plate", vehicle4.LicensePlateNumber);
        }

        [Test]
        public void TestIsConstructorVehicleWorksCorrectly()
        {
            Vehicle vehicle4 = new Vehicle("ZaAsd", "Kmodel", "346756");
            
            Assert.AreEqual("ZaAsd", vehicle4.Brand);
            Assert.AreEqual("Kmodel", vehicle4.Model);
            Assert.AreEqual("346756", vehicle4.LicensePlateNumber);
            Assert.AreEqual(100, vehicle4.BatteryLevel);
            Assert.AreEqual(false, vehicle4.IsDamaged);
            Assert.IsNotNull(vehicle4);
        }

        [Test]
        public void TestDriveVehicle_WorksCorrectly_WhenAddedDamagedOrBatteryDrainageMoreThan100()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Asd", "model", "12234");
            vehicle.BatteryLevel = 100;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("12234", 1000, false);

            Assert.IsFalse(vehicle.IsDamaged);
        }
    }
}