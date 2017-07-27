using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using NeuOldDriver.Models;
using NeuOldDriver.Extensions;

using HtmlAgilityPack;

namespace NeuOldDriver.ViewModels {

    /// <summary>
    /// Courses at specific day and course schedule
    /// </summary>
    public class CourseList : ViewModelBase {
        public List<Course> courses;
        public int week;

        public CourseList() {
            courses = new List<Course>();
            week = 0;
        }

        public int Week {
            get { return week; }
            set { week = value; OnPropertyChanged(nameof(Week)); OnPropertyChanged(nameof(Text)); }
        }

        public string Text {
            get {
                var data = courses.Where(course => course.weeks[week]).FirstOrDefault();
                return data == null ? "" : data.ToString();
            }
        }

        /// <summary>
        /// Get courses by week
        /// </summary>
        /// <param name="week">week number, from 0 to 19</param>
        /// <returns>A single course</returns>
        public Course this[int week] {
            get { return courses.Where(course => course.weeks[week]).FirstOrDefault(); }
        }

        public void Append(IEnumerable<Course> list) {
            courses.AddRange(list);
        }

        public static implicit operator List<Course>(CourseList list) {
            return list.courses;
        }
    }

    public class CourseTableViewModel : ViewModelBase {

        /// <summary>
        /// Courses in one week, from monday(0) to sunday(6) -- first dimension
        /// <para>Courses in one day, from course 1-2 (0) to course 11-12 (5) -- second dimension</para>
        /// </summary>
        private CourseList[][] courses;

        private string term = "";
        private string studentInfo = "";

        private int week = 0;

        public string Term {
            get { return term; }
            private set { term = value; OnPropertyChanged(nameof(Term)); }
        }

        public string StudentInfo {
            get { return studentInfo; }
            private set { studentInfo = value; OnPropertyChanged(nameof(StudentInfo)); }
        }

        public int Week {
            get { return week; }
            set {
                week = value;
                courses.Merge().ForEach(list => list.Week = value);
            }
        }

        public CourseTableViewModel() {
            courses = new CourseList[7][];
            for (var row = 0; row < 7; ++row) {
                courses[row] = new CourseList[6];
                for (var col = 0; col < 6; ++col)
                    courses[row][col] = new CourseList();
            }
        }
        
        public CourseList[] this[int weekday] {
            get { return courses[weekday]; }
        }

        public void LoadCourses(string html) {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var container = document.DocumentNode.SelectSingleNode("html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table");

            for (var col = 0; col < 6; ++col) { // course 
                for (var row = 0; row < 7; ++row) { // weekdays
                    var result = ParseHTML(container, String.Format("tr[{0}]/td[{1}]", col + 4, row + 2));
                    courses[row][col].Append(ParseCourses(result));
                }
            }

            Term = String.Join(" ", ParseHTML(container, "tr[1]/td[1]"));
            StudentInfo = String.Join(" ", ParseHTML(container, "tr[2]/td[1]")).Replace("&nbsp;", "");
        }
        
        /// <summary>
        /// Parse html into list of strings
        /// </summary>
        /// <param name="html">content of html, UTF-8 encoding</param>
        /// <param name="xpath">xpath to element</param>
        /// <returns></returns>
        public static IEnumerable<string> ParseHTML(HtmlNode parent, string xpath) {
            return parent.SelectSingleNode(xpath)?.ChildNodes
                .Where(node => node.Name != "br" && node.InnerText != "&nbsp;")
                .Select(node => node.InnerText);
        }

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

        public static IList<Course> ParseCourses(IEnumerable<string> src) {
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
    }
}
