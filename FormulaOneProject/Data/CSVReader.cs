using System;
using System.IO;
using System.Collections.Generic;
using FormulaOneProject.Models;

namespace FormulaOneProject.Data
{
    public class CSVReader
    {
        public static List<Car> LoadCars(string filePath)
        {
            List<Car> cars = new List<Car>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Skip the header row
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] carData = line.Split(',');
                    Car car = new Car(
                        model: carData[0],
                        speed: double.Parse(carData[1]),
                        tireWear: double.Parse(carData[2]),
                        fuelLevel: double.Parse(carData[3])
                    );
                    cars.Add(car);
                }
            }
            return cars;
        }

        public static List<Driver> LoadDrivers(string filePath)
        {
            List<Driver> drivers = new List<Driver>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Skip the header row
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] driverData = line.Split(',');
                    Driver driver = new Driver(
                        name: driverData[0],
                        skillLevel: int.Parse(driverData[1]),
                        aggression: int.Parse(driverData[2])
                    );
                    drivers.Add(driver);
                }
            }
            return drivers;
        }

        public static List<Track> LoadTracks(string filePath)
        {
            List<Track> tracks = new List<Track>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Skip the header row
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] trackData = line.Split(',');
                    string name = trackData[0];
                    double length = double.Parse(trackData[1]);
                    int numberOfLaps = int.Parse(trackData[2]);
                    int numberOfCorners = int.Parse(trackData[3]);
                    bool hasHighSpeedSections = bool.Parse(trackData[4]);
                    double baseLapTime = double.Parse(trackData[5]);

                    Track track;
                    if(hasHighSpeedSections && numberOfCorners <= 12)
                    {
                        track = new HighSpeedTrack(name, length, numberOfLaps, numberOfCorners, hasHighSpeedSections, baseLapTime);
                    }
                    else
                    {
                        track = new LowSpeedTrack(name, length, numberOfLaps, numberOfCorners, hasHighSpeedSections, baseLapTime);
                    }

                    tracks.Add(track);
                }
            }
            return tracks;
        }
    }
}
