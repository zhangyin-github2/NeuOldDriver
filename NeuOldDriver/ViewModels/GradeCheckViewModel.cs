using System;
using System.Linq;
using System.Text.RegularExpressions;

using NeuOldDriver.Utils;
using NeuOldDriver.Models;

using HtmlAgilityPack;

namespace NeuOldDriver.ViewModels {

    public class GradeCheckViewModel : ViewModelBase {

        private string studentInfo;
        private Grade[] grades;
        private int courses;

        public string StudentInfo {
            get { return studentInfo; }
            private set { studentInfo = value; OnPropertyChanged(nameof(StudentInfo)); }
        }

        /// <summary>
        /// Count of courses
        /// </summary>
        public int Courses {
            get { return courses; }
        }

        public Grade[] Grades {
            get { return grades; }
        }

        public void LoadGrades(string html) {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            var parent = document.DocumentNode.SelectSingleNode("html/body/table/tr[2]/td/table");
            var info = HTMLUtils.ParseHTML(parent, "tr/td/table/tr/td").First().Split(new[] { "&nbsp;", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            StudentInfo = String.Join(" ", info);

            var container = parent.SelectSingleNode("tr[2]/td/div/table");

            // class count text in html, has the form "共有记录数(\d+)"
            courses = Convert.ToInt32(Regex.Match(HTMLUtils.ParseHTML(container, "tr[last()]/td").First(), @"共有记录数(\d+)").Groups[1].Value);
            grades = new Grade[courses];
            
            for (var row = 0; row < courses; ++row) 
                grades[row] = ParseGrade(container, row + 2);
        }

        private static Grade ParseGrade(HtmlNode container, int row) {
            return Grade.Deserialize((new[] { 3, 6, 8, 9, 10, 11 }).Select((col) => {
                var parsed = HTMLUtils.ParseHTML(container, String.Format("tr[{0}]/td[{1}]", row, col));
                return parsed.FirstOrDefault()?.Replace("&nbsp;", "");
            }));
        }
    }
}