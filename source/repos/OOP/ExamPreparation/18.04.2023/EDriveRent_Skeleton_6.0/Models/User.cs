using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string drivingLicsence;
        private double rating;
        private string lastName;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            Rating = 0;
            IsBlocked=false;
        }

        public string FirstName
        {
            get { return firstName; }
           private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }


        public string LastName
        {
            get { return lastName; }
          private  set {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value; }
        }


        public string DrivingLicenseNumber
        {
            get { return drivingLicsence; }
          private  set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicsence = value; }
        }




        public double Rating 
        { 
        get=> rating;
            private set
            {
                rating=value
                    ;
            }
        }

       

        public bool IsBlocked { get; private set; }

        public void DecreaseRating()
        {
           //Rating -= 2;
            if (Rating<=2)
            {
                Rating = 0;
                IsBlocked = true;
            }
            else
            {
                Rating -= 2;
            }

        }

        public void IncreaseRating()
        {
            Rating += 0.5;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
