using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core.Contracts
{
    public class Controller : IController
    {
        private BoothRepository booths;
        string[] validDelicaciesType = { "Gingerbread", "Stolen" };

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int id = booths.Models.Count + 1;
            IBooth booth = new Booth(id, capacity);
            booths.AddModel(booth);

            return $"Added booth number {id} with capacity {capacity} in the pastry shop!";
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);

            var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (!validDelicaciesType.Contains(delicacyTypeName))
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            else if (delicacy != null)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }
            else
            {
                if (delicacyTypeName == "Stolen")
                {
                    delicacy = new Stolen(delicacyName);
                }
                else if (delicacyTypeName == "Gingerbread")
                {
                    delicacy = new Gingerbread(delicacyName);
                }
                booth.DelicacyMenu.AddModel(delicacy);

                return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
            }
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);
            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            else if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }
            else if (cocktail != null)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }
            else
            {
                if (cocktailTypeName == "MulledWine")
                {
                    cocktail = new MulledWine(cocktailName, size);
                }
                else if (cocktailTypeName == "Hibernation")
                {
                    cocktail = new Hibernation(cocktailName, size);
                }
                booth.CocktailMenu.AddModel(cocktail);
                return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
            }

        }


        public string ReserveBooth(int countOfPeople)
        {
            var availableBooth = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).OrderBy(c => c.Capacity).ThenByDescending(c => c.BoothId).FirstOrDefault();

            if (availableBooth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            else
            {
                availableBooth.ChangeStatus();
                return $"Booth {availableBooth.BoothId} has been reserved for {countOfPeople} people!";
            }

        }

        public string TryOrder(int boothId, string order)
        {
            string[] tokens = order.Split("/");
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOrderedPieces = int.Parse(tokens[2]);
            var size = string.Empty;

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                size = tokens[3];
            }

            var booth = booths.Models.First(b => b.BoothId == boothId);
            var boothDelicacyRepo = booth.DelicacyMenu;
            var boothCocktailRepo = booth.CocktailMenu;


            if (itemTypeName != "Stolen" && itemTypeName != "MulledWine" && itemTypeName != "Gingerbread" && itemTypeName != "Hibernation")
            {
                return $"{itemTypeName} is not recognized type!";
            }


            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName /*&& c.Size==size*/))
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

               
                var cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);
                if (cocktail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth.UpdateCurrentBill(countOrderedPieces*cocktail.Price);
                return $"Booth {boothId} ordered {countOrderedPieces} {itemName}!";
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(c => c.Name == itemName ))
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                var delicacy = booth.DelicacyMenu.Models.First(d=>d.Name== itemName );

                if (delicacy == null)
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }
                booth.UpdateCurrentBill(countOrderedPieces * delicacy.Price);
                return $"Booth {boothId} ordered {countOrderedPieces} {itemName}!";

            }
            
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);
            return booth.ToString() ;
          
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);
            var currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }


    }
}
