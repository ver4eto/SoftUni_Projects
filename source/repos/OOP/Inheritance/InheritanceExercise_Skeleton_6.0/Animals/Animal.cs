using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private string _name;
        private string _gender;
        private int _age;

        public Animal(string name,  int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                  _name = value;
                
            }
        }
        public string Gender {
            get
            {
                return _gender;
            }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                
                    _gender = value;
                
            } 
        }
        public int Age {

            get {  return _age; }
           private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                _age = value;
            }
        }

        public abstract string ProduceSound();
       
        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}
