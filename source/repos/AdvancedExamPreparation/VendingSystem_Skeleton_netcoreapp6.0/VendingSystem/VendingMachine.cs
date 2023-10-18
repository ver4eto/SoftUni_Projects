using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        private int buttonCapacity;
        private List<Drink> drinks;


        public VendingMachine(int capacity)
        {
            this.ButtonCapacity = capacity;
            this.Drinks = new List<Drink>();
        }
        public int ButtonCapacity {  get { return buttonCapacity; }  private set {  buttonCapacity = value; } }
        public List<Drink> Drinks { get {  return drinks; } private set {  drinks = value; } }

        public int GetCount => drinks.Count;        

        public void AddDrink(Drink drink)
        {
            int currentCount = this.GetCount;
            if (currentCount < this.ButtonCapacity)
            {
                this.Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            Drink currentDrink = this.drinks.FirstOrDefault(d=>d.Name == name);
            if (currentDrink != null)
            {
                this.drinks.Remove(currentDrink);
                return true;
            }
            return false;
        }

        public Drink GetLongest()
        {
            Drink longest=this.drinks.MaxBy(d=>d.Volume);
            return longest;
        }

        public Drink GetCheapest()
        {
            Drink drink = this.drinks.MinBy(d=>d.Price);
            return drink;
        }

        public string BuyDrink(string name)
        {
            Drink current = this.drinks.FirstOrDefault(dr => dr.Name == name);
            return current.ToString();
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Drinks available:");
            foreach (var drink in this.drinks)
            {
                stringBuilder.AppendLine(drink.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
