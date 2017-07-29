using System.Collections.Generic;

namespace NeuOldDriver.Models {
    public class ExamRoom {

        public string name { get; set; }
        public string time { get; set; }
        public string location { get; set; }
        public string room { get; set; }

        public static ExamRoom Deserialize(IEnumerable<string> list) {
            using (var i = list.GetEnumerator()) {
                return new ExamRoom() {
                    name = i.MoveNext() ? (i.Current ?? "") : "",
                    time = i.MoveNext() ? (i.Current ?? "") : "",
                    location = i.MoveNext() ? (i.Current ?? "") : "",
                    room = i.MoveNext() ? (i.Current ?? "") : ""
                };
            }
        }

        public IList<string> Serialize() {
            return new List<string>() {
                name, time, location, room
            };
        }
    }
}
