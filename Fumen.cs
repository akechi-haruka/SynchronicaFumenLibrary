using Newtonsoft.Json;
using SynchronicaFumenLibrary.Events;
using SynchronicaFumenLibrary.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SynchronicaFumenLibrary.Events.MoveMarker;

namespace SynchronicaFumenLibrary
{
    public class Fumen {

        public static readonly String[] OFFICIAL_TAG_LIST = {
            "NONE",
            "JPOP",
            "VOCALOID",
            "ANIME",
            "GAME",
            "CLASSIC",
            "ORIGINAL",
            "VARIETY"
        };

        public List<TimelineEvent> timeline;

        public static Fumen Read(String file) {
            if (!File.Exists(file)) {
                throw new ArgumentException("File doesn't exist: " + file);
            }
            Fumen f = (Fumen)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(Fumen));
            return f;
        }

        public void Save(String file) {
            File.WriteAllText(file, JsonConvert.SerializeObject(this));
        }

        public static Marker CreateTap(double _time, float _x, float _y, bool is_off_beat = false) {
            return new Marker() {
                event_type = "marker",
                marker_type = "touch",
                x = _x,
                y = _y,
                beat = is_off_beat ? 0.5F : 1,
                edit_layer = 2,
                time = _time
            };
        }

        public static HoldMarker CreateHold(double _time, float _x, float _y, float _duration, bool is_off_beat = false) {
            return new HoldMarker() {
                event_type = "marker",
                marker_type = "hold",
                x = _x,
                y = _y,
                beat = is_off_beat ? 0.5F : 1,
                edit_layer = 2,
                time = _time,
                duration = _duration
            };
        }

        public static SwipeMarker CreateSwipe(double _time, float _x, float _y, int _direction, bool is_off_beat = false) {
            return new SwipeMarker() {
                event_type = "marker",
                marker_type = "swipe",
                x = _x,
                y = _y,
                beat = is_off_beat ? 0.5F : 1,
                edit_layer = 2,
                time = _time,
                direction = _direction
            };
        }

        public static SwipeMarker CreateFlick(double _time, float _x, float _y, int _direction, bool is_off_beat = false) {
            return new SwipeMarker() {
                event_type = "marker",
                marker_type = "flick",
                x = _x,
                y = _y,
                beat = is_off_beat ? 0.5F : 1,
                edit_layer = 2,
                time = _time,
                direction = _direction
            };
        }

        public static MoveMarker CreateMove(double _time, float _x, float _y, float _duration, PathType _method, List<Point> points, bool is_off_beat = false) {
            PathInformation p = new PathInformation {
                duration = _duration,
                method = _method.ToString().ToLower(),
                control_point = points
            };
            return new MoveMarker() {
                event_type = "marker",
                marker_type = "move",
                x = _x,
                y = _y,
                beat = is_off_beat ? 0.5F : 1,
                edit_layer = 2,
                time = _time,
                path = new List<PathInformation> {
                    p // todo multiple paths??
                }
            };
        }

        public static DummyMarker CreateDummy(double _time, params String[] _tags) {
            return new DummyMarker() {
                event_type = "marker",
                marker_type = "dummy",
                x = 0.5F,
                y = 0.5F,
                beat = 1,
                edit_layer = 8,
                time = _time,
                tags = _tags.ToList()
            };
        }

        public static Tempo CreateBPMChange(double _bpm, double _offset) {
            return new Tempo() {
                event_type = "tempo",
                bpm = _bpm,
                time = _offset
            };
        }
    }
}
