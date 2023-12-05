using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private DelicacyRepository delicacyRepository;
        private CocktailRepository cocktailRepository;

       // private double currentBill;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
            delicacyRepository = new DelicacyRepository();
            cocktailRepository = new CocktailRepository();
        }

        public int BoothId {
            get { return boothId; }

          private set 
            { 
            boothId = value;
            } }

        public int Capacity
        {
            get { return capacity; }
          private  set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyRepository;

        public IRepository<ICocktail> CocktailMenu => cocktailRepository;

        public double CurrentBill {

            get;
            private set;
        }

        public double Turnover
        {

            get;
            private set;
        }

        public bool IsReserved
        {

            get;
            private set;
        }

        public void ChangeStatus()
        {
          if (IsReserved == true)
            {
                IsReserved = false;
            }
          else if(IsReserved == false)
            {
                IsReserved = true;
            }
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");           
            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in cocktailRepository.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in delicacyRepository.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
