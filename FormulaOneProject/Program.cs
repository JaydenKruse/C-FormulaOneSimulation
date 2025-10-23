using System;
using System.Collections.Generic;
using FormulaOneProject.Models;
using FormulaOneProject.Simulations;
using FormulaOneProject.Data;

namespace FormulaOneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = CSVReader.LoadCars("C:/Users/Jayden Kruse/source/repos/FormulaOneProject/FormulaOneProject/Data/Cars.csv");
            List<Driver> drivers = CSVReader.LoadDrivers("C:/Users/Jayden Kruse/source/repos/FormulaOneProject/FormulaOneProject/Data/Drivers.csv");
            List<Track> tracks = CSVReader.LoadTracks("C:/Users/Jayden Kruse/source/repos/FormulaOneProject/FormulaOneProject/Data/Tracks.csv");

            //Select random track
            Track selectedTrack = TrackSelect.SelectRandomTrack(tracks);

            //Qualifying Simulator
            QualiSim quali = new QualiSim(selectedTrack, cars, drivers);
            Console.WriteLine($"Starting qualifying at {selectedTrack.Name}");
            quali.QualiStart();

            //Reset car stats for race
            quali.ResetForRace();

            //Race Simulator
            RaceStart race = new RaceStart(selectedTrack, cars, drivers);
            Console.WriteLine($"Starting the race at {selectedTrack.Name}");
            race.StartRace();
        }
    }
}
