using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository userRepository;
        private VehicleRepository vehicleRepository;
        private RouteRepository routeRepository;

        public Controller()
        {
            userRepository = new UserRepository();
            vehicleRepository = new VehicleRepository();
            routeRepository = new RouteRepository();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user = userRepository.FindById(drivingLicenseNumber);
            if (user == null)
            {
                user = new User(firstName, lastName, drivingLicenseNumber);
                userRepository.AddModel(user);
                return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";

            }
            else
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            IVehicle vehicle = vehicleRepository.FindById(licensePlateNumber);
            if (vehicleType != "CargoVan" && vehicleType != "PassengerCar")
            {
                return $"{vehicleType} is not accessible in our platform.";
            }
            else if (vehicle != null)
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }
            else
            {
                if (vehicleType == "PassengerCar")
                {
                    vehicle = new PassengerCar(brand, model, licensePlateNumber);
                }
                else if (vehicleType == "CargoVan")
                {
                    vehicle = new CargoVan(brand, model, licensePlateNumber);
                }
                vehicleRepository.AddModel(vehicle);
                return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
            }
        }
        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            IReadOnlyCollection<IRoute> routes = routeRepository.GetAll();

            
            if(routes.FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length) != null)
            {
                return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
            }
            else if(routes.FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length) != null)
            {
                return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
            }
            else
            {
                int id = routes.Count() + 1;
                IRoute route = new Route(startPoint, endPoint, length, id);
                routeRepository.AddModel(route);

                if(routes.FirstOrDefault(r=>r.StartPoint==startPoint && r.EndPoint==endPoint && r.Length>length) != null)
                {
                    IRoute longerRoute = routes.FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);
                    longerRoute.LockRoute();
                   
                }
                return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
            }
                
           
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = userRepository.FindById(drivingLicenseNumber);
            if (user.IsBlocked==true)
            {
                return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
            }
            IVehicle vehicle = vehicleRepository.FindById(licensePlateNumber);
            if (vehicle.IsDamaged == true)
            {
                return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
            }
            IRoute route = routeRepository.FindById(routeId);
            if (route.IsLocked == true)
            {
                return $"Route {routeId} is locked! Trip is not allowed.";
            }

            vehicle.Drive(route.Length);
            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus() ;
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }
            return vehicle.ToString() ; 
        }


        public string RepairVehicles(int count)
        {
            List<IVehicle> damagedVehicles = vehicleRepository.GetAll().Where(v => v.IsDamaged == true).OrderBy(v => v.Brand).ThenBy(v => v.Model).ToList();
            int countOfVehicles = damagedVehicles.Count;
            List<IVehicle> selectedVehicles;
            if (countOfVehicles > count)
            {
                selectedVehicles = damagedVehicles.Take(count).ToList();
            }
            else
            {

                selectedVehicles = damagedVehicles;
            }
            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return $"{selectedVehicles.Count()} vehicles are successfully repaired!";
        }


        public string UsersReport()
        {
            StringBuilder sb = new StringBuilder();

            List<IUser> users = userRepository.GetAll().ToList();

            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in users.OrderByDescending(u=>u.Rating).ThenBy(u=>u.LastName).ThenBy(u=>u.FirstName))
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().TrimEnd() ;
        }
    }
}
