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
            using (var i = list.GetEnumerator()) {
                return new Grade() {
                    name = i.MoveNext() ? (i.Current ?? "") : "",
                    credit = i.MoveNext() ? (i.Current ?? "") : "",
                    general = i.MoveNext() ? (i.Current ?? "") : "",
                    midterm = i.MoveNext() ? (i.Current ?? "") : "",
                    final = i.MoveNext() ? (i.Current ?? "") : "",
                    total = i.MoveNext() ? (i.Current ?? "") : ""
                };
            }
        }

        public IList<string> Serialize() {
            return new List<string>() {
                name, credit, general, midterm, final, total
            };
        }
    }
}
