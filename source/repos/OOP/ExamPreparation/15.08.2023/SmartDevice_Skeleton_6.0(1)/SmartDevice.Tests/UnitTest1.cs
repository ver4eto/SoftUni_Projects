namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        private int memoryCapacity = 1000;
        private string appName = "flappy bird";
        private const int photoSize = 100;
        private const int appSize = 300;





        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Test_Constructor_Saves_Correctly()
        {
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Test_Photo_Works_Correctly()
        {

            bool result = device.TakePhoto(photoSize);

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity - photoSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_“‡ÍÂPhotos_DoesntSave_When_NoCapacity_Available()
        {

            bool result = device.TakePhoto(memoryCapacity + photoSize);

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_InstallApplication_WorksProperly()
        {
            string result = device.InstallApp(appName, appSize);

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity - appSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual(true, device.Applications.Contains(appName));
            Assert.AreEqual($"{appName} is installed successfully. Run application?", result);
        }

        [Test]
        public void Test_InstallApplication_Throws_WhenNoMemory()
        {
            Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, 5000));


        }

        [Test]
        public void Test_FormatDevice_WorksProperly()
        {
            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);

            device.FormatDevice();

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Test_GetDiveceStatus_WorksProperly()
        {
            device.InstallApp(appName, appSize);
            device.InstallApp(appName + "2", appSize + 30);
            device.TakePhoto(photoSize);
            var result = device.GetDeviceStatus();
            Assert.AreEqual($"Memory Capacity: 1000 MB, Available Memory: 270 MB{Environment.NewLine}Photos Count: 1{Environment.NewLine}Applications Installed: flappy bird, flappy bird2", result);

        }
    }
}