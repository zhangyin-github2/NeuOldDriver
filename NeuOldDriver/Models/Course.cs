using System;
using System.Text;

namespace NeuOldDriver.Models {

    public class Course {
        public string name { get; set; }
        public string teacher { get; set; }
        public string location { get; set; }
        public bool[] weeks { get; set; }

        public override string ToString() {
            var sb = new StringBuilder(name);
            if (!String.IsNullOrWhiteSpace(teacher))
                sb.Append('\n').Append(teacher);
            sb.Append('\n').Append(location);
            return sb.ToString();
        }
    };
}
