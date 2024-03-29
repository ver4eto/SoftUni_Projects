﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;    
        private int age;
        public string Name { get { return name; } set { name = value; } }
        public virtual int Age {
            get { return age; } 
            set 
            {
                if (value > 0)
                {
                    this.age = value;
                }
            } 
        }
        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            return stringBuilder.ToString().TrimEnd(); 
        }
    }
}
