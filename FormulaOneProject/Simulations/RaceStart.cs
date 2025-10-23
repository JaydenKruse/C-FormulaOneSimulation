using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FormulaOneProject.Models;

namespace FormulaOneProject.Simulations
{
    public class RaceStart
    {
        //Attributes
        private Track _track;
        private List<Car> _cars;
        private List<Driver> _drivers;
        private LapSimulation _lapSimulation;

        //Constructor
        public RaceStart(Track track, List<Car> cars, List<Driver> drivers)
        {
            _track = track;
            _cars = cars;
            _drivers = drivers;
            _lapSimulation = new LapSimulation();
        }

        //Methods
        public void StartRace()
        {
            for (int lap = 1; lap <= _track.NumberOfLaps; lap++)
            {
                var standings = _drivers.OrderBy(driver => driver.TotalTime).ToList();

                Console.WriteLine($"Lap {lap} results:");

                for (int i = 0; i < _cars.Count; i++)
                {
                    Car car = _cars[i];
                    Driver driver = _drivers[i];

                    if(car.TireWear >= 70)
                    {
                        driver.NeedToPit = true;
                    }
                    
                    double lapTime = _lapSimulation.SimulateLap(car, driver, _track, _cars, _drivers, i, lap);

                    Console.WriteLine($"{i + 1}. {standings[i].Name} - Lap Time: {lapTime:F2} seconds");

                    if (car.FuelLevel <= 0)
                    {
                        Console.WriteLine($"{driver.Name} ran out of fuel!");
                    }

                    int NumberOfPits = _lapSimulation.NumPits(driver);
                    if (_track.NumberOfLaps - lap == 0)
                    {
                        Console.WriteLine($"{driver.Name}: {NumberOfPits} pitstops.");
                    }

                }

                if (lap == _track.NumberOfLaps)
                {
                    for (int position = 0; position < standings.Count; position++)
                    {
                        Console.WriteLine($" Overall Race: {position + 1}. {standings[position].Name} - {standings[position].TotalTime:F2} seconds");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

