using SynchronicaFumenLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicaFumenLibrary.Events {
    public class MoveMarker : Marker {

        public List<PathInformation> path = new List<PathInformation>();

        public class PathInformation {

            public String method;
            public float duration;
            public List<Point> control_point = new List<Point>();

        }

        public enum PathType {
            Line, Spline, Bezier
        }
    }
}
