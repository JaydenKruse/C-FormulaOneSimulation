using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneProject.Models
{
    public class LowSpeedTrack : Track
    {
        public LowSpeedTrack(string name, double length, int numberOfLaps, int numberOfCorners, bool hasHighSpeedSections, double baseLapTime) : base(name, length, numberOfLaps, numberOfCorners, hasHighSpeedSections, baseLapTime)
        {

        }
        public override double AdjustedLapTime(double baseLapTime)
        {
            return baseLapTime * 1.10;
        }
    }
}
