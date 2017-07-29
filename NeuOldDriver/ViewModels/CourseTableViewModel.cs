using System;
using System.Linq;
using System.Collections.Generic;

using NeuOldDriver.Utils;
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
            set {
                if (week == value)
                    return;
                SetProperty(ref week, value);
            }
        }

        public string Text {
            get {
                var data = courses.Where(course => course.weeks[week]).FirstOrDefault();
                return data == null ? "" : data.ToString();
            }
        }
        
        public List<Course> Courses {
            get { return courses; }
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
            private set { SetProperty(ref term, value); }
        }

        public string StudentInfo {
            get { return studentInfo; }
            private set { SetProperty(ref studentInfo, value); }
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
                    var result = HTMLUtils.ParseHTML(container, String.Format("tr[{0}]/td[{1}]", col + 4, row + 2));
                    courses[row][col].Courses.AddRange(Course.Deserialize(result));
                }
            }

            Term = String.Join(" ", HTMLUtils.ParseHTML(container, "tr[1]/td[1]"));
            StudentInfo = String.Join(" ", HTMLUtils.ParseHTML(container, "tr[2]/td[1]").First()
                                            .Split(new[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries)
                                     );
        }

        

        
    }
}
