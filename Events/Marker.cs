using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicaFumenLibrary.Events {
    public class Marker : TimelineEvent {

        public int direction;
        public String marker_type;
        public float x;
        public float y;
        public float beat;
        public List<String> tags = new List<string>();
        public int edit_layer;
        public List<Int32> link_id = new List<int>();
        public List<Int32> edit_group_id = new List<int>();
        public bool edit_locked;

    }
}
