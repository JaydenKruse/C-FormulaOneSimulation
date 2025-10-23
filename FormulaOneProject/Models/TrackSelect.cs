using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneProject.Models
{
    public static class TrackSelect
    {
        //Methods
        public static Track SelectRandomTrack(List<Track> tracks)
        {
            Random random = new Random();

            int randomIndex = random.Next(tracks.Count);

            return tracks[randomIndex];
        }
    }
}
