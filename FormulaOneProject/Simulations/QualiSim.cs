using FormulaOneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneProject.Simulations
{
    //Race but only for 1 lap, and resets timings, tirewear, and fuel levels afterwards
    internal class QualiSim
    {
        //Attributes
        private Track _track;
        private List<Car> _cars;
        private List<Driver> _drivers;
        private LapSimulation _lapSimulation;

        //Constructor
        public QualiSim(Track track, List<Car> cars, List<Driver> drivers)
        {
            _track = track;
            _cars = cars;
            _drivers = drivers;
            _lapSimulation = new LapSimulation();
        }
        //Methods
        public void QualiStart()
        {
            Console.WriteLine($"Quali results:");

            for (int i = 0; i < _cars.Count; i++)
            {
                Car car = _cars[i];
                Driver driver = _drivers[i];

                if (car.TireWear >= 70)
                {
                    driver.NeedToPit = true;
                }

                double lapTime = _lapSimulation.SimulateLap(car, driver, _track, _cars, _drivers, i, 1);

                if (car.FuelLevel <= 0)
                {
                    Console.WriteLine($"{driver.Name} ran out of fuel!");
                }
            }

            var standings = _drivers.OrderBy(d => d.TotalTime).ToList();
            for (int position = 0; position < standings.Count; position++)
            {
                Console.WriteLine($"{position + 1}. {standings[position].Name} - {standings[position].TotalTime:F2} seconds");
            }
            Console.WriteLine();
        }

        public void ResetForRace()
        {
            foreach (var driver in _drivers)
            {
                driver.TotalTime = 0; // Reset cumulative time
            }
            foreach (var car in _cars)
            {
                car.TireWear = 0;  // Reset tire wear
                car.FuelLevel = 100; // Reset fuel to full
            }
        }
    }
}
