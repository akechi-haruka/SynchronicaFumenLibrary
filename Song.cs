using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicaFumenLibrary {
    public class Song {

        public int id;
        public String name;
        public String filename;
        public String dirname;
        public String details;
        public List<Fumen> charts = new List<Fumen>();
        public double bpm;
        public double bpm2;
        public int preview_ms_start;
        public int preview_ms_end;
        public int ranking;
        public List<String> tags = new List<string>();

        public bool HasDifficulty(int chart_index) {
            return chart_index >= 0 && chart_index < charts.Count;
        }

        public int GetDifficultyRating(int chart_index) {
            return 5; // todo
        }

        public string GetIdString() {
            return id.ToString().PadLeft(4, '0');
        }
    }
}
