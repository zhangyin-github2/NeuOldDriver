using System.Linq;
using System.Collections.Generic;

namespace NeuOldDriver.Models {

    public class Grade {
        public string name { get; set; } // 课程名
        public string credit { get; set; } // 学分
        public string general { get; set; } // 平时成绩
        public string midterm { get; set; } // 期中成绩
        public string final { get; set; } // 期末成绩
        public string total { get; set; } // 总成绩

        public static Grade Deserialize(IEnumerable<string> list) {
            var props = list.ToList();
            return new Grade() {
                name = props[0] ?? "",
                credit = props[1] ?? "",
                general = props[2] ?? "",
                midterm = props[3] ?? "",
                final = props[4] ?? "",
                total = props[5] ?? ""
            };
        }

        public IList<string> Serialize() {
            return new List<string>() {
                name, credit, general, midterm, final, total
            };
        }
    }
}
