using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneProject.Models
{
    public class Car
    {
        //Attributes
        public string Model { get; set; }
        public double Speed { get; set; } // Speed in km/h
        public double TireWear { get; set; } // Tire wear percentage
        public double FuelLevel { get; set; } // Fuel level in liters

        //Constructor
        public Car(string model, double speed, double tireWear, double fuelLevel)
        {
            Model = model;
            Speed = speed;
            TireWear = tireWear;
            FuelLevel = fuelLevel;
        }

        //Methods
        public void DriveLap(double lapLength)
        {
            FuelLevel -= lapLength * 0.05;
            TireWear += 0.5;
        }

    }
}

