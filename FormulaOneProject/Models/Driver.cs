using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneProject.Models
{
    public class Driver
    {
        //Attributes
        public string Name { get; set; }
        public int SkillLevel { get; set; } // Skill level affects lap time
        public int Aggression { get; set; } // Aggression impacts risky maneuvers
        public bool NeedToPit { get; set; } = false;
        public double TotalTime { get; set; } = 0;
        public int NumberOfPits { get; set; }


        //Constructor
        public Driver(string name, int skillLevel, int aggression)
        {
            Name = name;
            SkillLevel = skillLevel;
            Aggression = aggression;
        }

        //Methods
        public void DeterminePitStop (double tirewearThreshold, int lapsRemaining)
        {
            NeedToPit = (tirewearThreshold >= 70);

            if(NeedToPit && lapsRemaining <= 5)
            {
                NeedToPit = false;
            }
        }

        public void ChanceOfMistake(Car car)
        {
            Random random = new Random();

            double mistakeProbability = (100 - SkillLevel) / 100.0 + (Aggression / 200.0);

            double randomChance = random.NextDouble();

            if(randomChance < mistakeProbability)
            {
                double penaltyTime = random.NextDouble() * (0.7 - 0.1) + 0.1;
                TotalTime += penaltyTime;
                double penaltyTireWear = random.NextDouble() * (1.0 - 0.5) + 1.0;
                car.TireWear += penaltyTireWear;
            }
        }
        public bool AttemptOvertake(double timeGap)
        {
            Random random = new Random();
            double overtakeChance = Aggression / 100.0;
            return timeGap <= 2.0 && random.NextDouble() < overtakeChance;
        }
        public bool PreserveTires(double positionGap, bool isInComfortablePosition)
        {
            Random random = new Random();
            double preservationChance = (100 - Aggression) / 100.0;
            return isInComfortablePosition || positionGap > 5.0 || random.NextDouble() < preservationChance;
        }
    }
}

