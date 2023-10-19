using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        //private List<Cloth> clothes;
        //private string type;
        //private int capacity;

        public Magazine(string type, int capacity)
        {
            this.Clothes = new List<Cloth>();
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public int GetClothCount => this.Clothes.Count;
        public void AddCloth(Cloth cloth)
        {
            if (GetClothCount<this.Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = this.Clothes.FirstOrDefault(c => c.Color == color);
            if (cloth != null)
            {
                this.Clothes.Remove(cloth);
                return true;
            }
            return false;
        }

        public Cloth GetSmallestCloth()
        {
            return this.Clothes.OrderBy(c=>c.Size).FirstOrDefault();
        }

        public Cloth GetCloth(string color)
        {
            return this.Clothes.FirstOrDefault(c=>c.Color == color);
        }

        public string Report()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{this.Type} magazine contains:");
            foreach (var magazine in this.Clothes.OrderBy(m=>m.Size))
            {
                sb.AppendLine(magazine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
