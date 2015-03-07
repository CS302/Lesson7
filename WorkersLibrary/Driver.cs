﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersLibrary
{
    public sealed class Driver : Worker, IPayTax
    {
        public string carType;
        public int hours;

        public double PayTax()
        {
            return 0.13 * salary;
        }

        public Driver(string name, int age, Int64 snn, string carType,
            int hours)
            : base(name, age, snn)
        {
            this.carType = carType;
            this.hours = hours;
            salary = 35000;
        }

        public override int GetBonus()
        {
            return hours * 100;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Марка машины: " + carType);
            Console.WriteLine("Количество часов: " + hours);
            Console.WriteLine();
        }
    }
}
