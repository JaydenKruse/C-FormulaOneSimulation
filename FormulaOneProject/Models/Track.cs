using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneProject.Models
{
    public abstract class Track
    {
        //Attributes
        public string Name { get; set; }
        public double Length { get; set; } // Track length in km
        public int NumberOfLaps { get; set; }
        public int NumberOfCorners { get; set; }
        public bool HasHighSpeedSections { get; set; }
        public double BaseLapTime { get; set; }

        //Constructor
        public Track(string name, double length, int numberOfLaps, int numberOfCorners, bool hasHighSpeedSections, double baseLapTime)
        {
            Name = name;
            Length = length;
            NumberOfLaps = numberOfLaps;
            NumberOfCorners = numberOfCorners;
            HasHighSpeedSections = hasHighSpeedSections;
            BaseLapTime = baseLapTime;
        }

        //Methods
        public abstract double AdjustedLapTime(double baselapTime);
    }
}

