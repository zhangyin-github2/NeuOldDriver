using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using NeuOldDriver.Net;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CourseTable : Page
    {
        TextBlock[][] textBlocks = new TextBlock[6][];
        string[][][] stringss = new string[20][][];

        public CourseTable() {
            this.InitializeComponent();

            this.Loaded += async (sender, e) => {
                vm.LoadCourses(await AAOAPI.RequestInfomation("学生课程表"));
            }; 
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < 20; j++)
            {
                stringss[j] = new string[6][];
                for (int i = 0; i < 6; i++)
                {
                    stringss[j][i] = new string[7];
                }
            }

            for (int i = 0; i < 6; i++)
            {
                textBlocks[i] = new TextBlock[7];
            }

            textBlocks[0][0] = MON12;
            textBlocks[1][0] = MON34;
            textBlocks[2][0] = MON56;
            textBlocks[3][0] = MON78;
            textBlocks[4][0] = MON910;
            textBlocks[5][0] = MON1112;

            textBlocks[0][1] = TUE12;
            textBlocks[1][1] = TUE34;
            textBlocks[2][1] = TUE56;
            textBlocks[3][1] = TUE78;
            textBlocks[4][1] = TUE910;
            textBlocks[5][1] = TUE1112;

            textBlocks[0][2] = WED12;
            textBlocks[1][2] = WED34;
            textBlocks[2][2] = WED56;
            textBlocks[3][2] = WED78;
            textBlocks[4][2] = WED910;
            textBlocks[5][2] = WED1112;

            textBlocks[0][3] = THU12;
            textBlocks[1][3] = THU34;
            textBlocks[2][3] = THU56;
            textBlocks[3][3] = THU78;
            textBlocks[4][3] = THU910;
            textBlocks[5][3] = THU1112;

            textBlocks[0][4] = FRI12;
            textBlocks[1][4] = FRI34;
            textBlocks[2][4] = FRI56;
            textBlocks[3][4] = FRI78;
            textBlocks[4][4] = FRI910;
            textBlocks[5][4] = FRI1112;

            textBlocks[0][5] = STA12;
            textBlocks[1][5] = STA34;
            textBlocks[2][5] = STA56;
            textBlocks[3][5] = STA78;
            textBlocks[4][5] = STA910;
            textBlocks[5][5] = STA1112;

            textBlocks[0][6] = SUN12;
            textBlocks[1][6] = SUN34;
            textBlocks[2][6] = SUN56;
            textBlocks[3][6] = SUN78;
            textBlocks[4][6] = SUN910;
            textBlocks[5][6] = SUN1112;

            //List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            //ComboBoxItem comboBoxIrem = new ComboBoxItem();

            for (int i = 1; i < 21; i++)
            {
                //comboBoxItems.Add(comboBoxIrem);
                comboBox1.Items.Add(new TextBlock() { Text = "第" + i + "周" });
            }
            ParseClassScheduleHTML();

        }



        private async void ParseClassScheduleHTML() {
            //课程信息, 把学生课程表页面的HTML返回给成string
            /*var html = await AAOAPI.RequestInfomation("学生课程表");

            for (var row = 4; row < 10; ++row) {

                for (var col = 2; col < 9; ++col) {
                    var xpathSchedule = String.Format("html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[{0}]/td[{1}]", row, col);

                    string strText = null;
                    bool secondIsWeeks = false;

                    //识别课程周数，把课程信息按周数，星期几，第几节，存放在一个三维string数组中
                    foreach (var line in AAOAPI.ParseHTML(html, xpathSchedule)) {
                        if(Char.IsNumber(line[0])) {
                            var weeks = AAOAPI.ParseWeekNumbers(line);
                            for (var i = 0; i < 20; ++i) {
                                if(weeks[i]) 
                                    stringss[i][row - 4][col - 2] = stringss[i][row - 4][col - 2] ?? "" + strText;
                            }
                            strText = null;
                            secondIsWeeks = true;
                        } else {
                            if ((strText == null) && !secondIsWeeks)
                                strText = line;
                            else if ((strText == null) && secondIsWeeks) {
                                strText = "\n" + line;
                                secondIsWeeks = false;
                            } else
                                strText = strText + "\n" + line;
                        }
                    }
                }
            }

            // 学期
            string xpathSemester = "html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[1]/td[1]";
            Semester.Text = String.Join(" ", AAOAPI.ParseHTML(html, xpathSemester));

            //院系
            string xpathStudentInformation = "html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[2]/td[1]";
            StudentInformation.Text = String.Join(" ", AAOAPI.ParseHTML(html, xpathStudentInformation))
                                        .Replace("&nbsp;", " ");*/
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = comboBox1.SelectedIndex;

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    textBlocks[j][i].Text = "";
                }
            }
            for (int j = 0; j < 6; j++)
            {
                for(int i = 0; i < 7; i++)
                {
                    if(stringss[x][j][i] != null)
                        textBlocks[j][i].Text = stringss[x][j][i];
                }
            }
        }

    };
}
