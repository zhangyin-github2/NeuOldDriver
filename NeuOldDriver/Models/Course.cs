using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using NeuOldDriver.Extensions;

namespace NeuOldDriver.Models {

    public class Course {
        public string name { get; set; }
        public string teacher { get; set; }
        public string location { get; set; }
        public bool[] weeks { get; set; }

        /// <summary>
        /// Parse week numbers according to given week string
        /// </summary>
        /// <param name="weeks">string representing weeks. for example "2-6.8-9周 4节"</param>
        /// <returns>array of bool indicating each week's presence</returns>
        public static bool[] ParseWeekNumbers(string weeks) {
            var ret = new bool[20];

            // trim trailing infomations
            weeks = Regex.Replace(weeks, @"\s*\d+节", "");

            Regex.Matches(weeks, @"([\d-]+)").Cast<Match>()
                .Select(match => match.Value)
                .ForEach((part) => {
                    var nums = Regex.Matches(part, @"(\d+)").Cast<Match>()
                                .Select(match => Convert.ToInt32(match.Value));
                    var count = nums.Count();
                    if (count == 1)
                        ret[nums.First() - 1] = true;
                    else if (count == 2) {
                        var to = nums.ElementAt(1);
                        for (var i = nums.First() - 1; i < to; ++i)
                            ret[i] = true;
                    }
                });

            return ret;
        }

        public static IList<Course> Deserialize(IEnumerable<string> src) {
            var ret = new List<Course>();
            /*
             可能的课程字符串序列布局：
                 课程名 教师名 教室 周数
             或者：
                 课程名 教室 周数
             */
            using (var i = src.GetEnumerator()) {
                while (i.MoveNext()) {
                    var course = new Course() {
                        name = i.Current,
                        teacher = ""
                    };
                    i.MoveNext();
                    var possibleTeacher = i.Current;
                    i.MoveNext();
                    var possibleLocation = i.Current;
                    if (Char.IsNumber(possibleLocation[0])) {
                        course.location = possibleTeacher;
                        course.weeks = ParseWeekNumbers(possibleLocation);
                    } else {
                        course.teacher = possibleTeacher;
                        course.location = possibleLocation;
                        i.MoveNext();
                        course.weeks = ParseWeekNumbers(i.Current);
                    }
                    ret.Add(course);
                }
            }
            return ret;
        }

        public override string ToString() {
            var sb = new StringBuilder(name);
            if (!String.IsNullOrWhiteSpace(teacher))
                sb.Append('\n').Append(teacher);
            sb.Append('\n').Append(location);
            return sb.ToString();
        }
    };
}
