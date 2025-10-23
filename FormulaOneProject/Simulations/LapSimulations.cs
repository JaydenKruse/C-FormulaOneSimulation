using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOneProject.Models;

namespace FormulaOneProject.Simulations
{
    public class LapSimulation
    {
        //I want to have each track have their own pit stop time since it ranges from track to track
        private const double _pitStopTime = 20.0;
        public double SimulateLap(Car car, Driver driver, Track track, List<Car> cars, List<Driver> drivers, int driverIndex, int currentLap)
        {
            double lapTime = track.BaseLapTime;

            int lapsRemaining = track.NumberOfLaps - currentLap;
            
            lapTime *= (100.0 / driver.SkillLevel); // Skill level adjustment
            lapTime *= (0.5 + car.TireWear / 100.0); // Tire wear adjustment
            lapTime = track.AdjustedLapTime(lapTime); // Adjust time based off of complexity of track

            //Determine if driver is close behind someone
            if(driverIndex > 0)
            {
                Car aheadCar = cars[driverIndex - 1];
                Driver aheadDriver = drivers[driverIndex - 1];

                double timeGap = aheadDriver.TotalTime - driver.TotalTime;

                ToeLap(car, driver, aheadCar, aheadDriver, timeGap);
            }

            //Aggresive Mode
            if(driverIndex > 0)
            {
                Driver aheadDriver = drivers[driverIndex - 1];
                double timeGap = aheadDriver.TotalTime - driver.TotalTime;

                if(driver.AttemptOvertake(timeGap))
                {
                    //Console.WriteLine($"{driver.Name} is going aggresive");
                    car.TireWear += 1.0;
                    lapTime -= 0.3;

                }
            }

            //Preservation Mode
            if(driver.PreserveTires(driverIndex == 0 ? 0 : drivers[driverIndex - 1].TotalTime - driver.TotalTime, driverIndex == 0))
            {
                //Console.WriteLine($"{driver.Name} is preserving tires");
                car.TireWear -= 1.0;
                lapTime += 0.3;
            }

            //Determine pit stop
            driver.DeterminePitStop(car.TireWear, lapsRemaining);
            if(driver.NeedToPit)
            {
                Console.WriteLine($"{driver.Name} is pitting");
                lapTime += _pitStopTime;
                car.TireWear = 0;
                driver.NeedToPit = false;
                driver.NumberOfPits += 1;
            }

            //Chance of mistake based off of corner count
            for(int i = 0; i < track.NumberOfCorners; i++)
            {
                driver.ChanceOfMistake(car);
            }

            driver.TotalTime += lapTime;

            car.DriveLap(track.Length);

            //Console.WriteLine($"{driver}: Tire Wear: {car.TireWear}");

            return lapTime;
        }
        public void ToeLap(Car currentCar, Driver currentDriver, Car aheadCar, Driver aheadDriver, double timeGap)
        {
            if (timeGap <= 2.0)
            {
                currentCar.FuelLevel += 0.05;

                currentCar.TireWear += 1.0;
            }
        }

        public int NumPits(Driver currentDriver)
        {
            return currentDriver.NumberOfPits;
        }
    }
}

