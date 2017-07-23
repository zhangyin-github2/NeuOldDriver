using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HtmlAgilityPack;
using NeuOldDriver.API;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ClassSchedule : Page
    {
        TextBlock[][] textBlocks = new TextBlock[6][];
        string[][][] stringss = new string[20][][];

        /// <summary>
        /// 定义的实体类用于接收数据
        /// </summary>
        public class Data
        {
            public string 内容 { get; set; }
        }

        public ClassSchedule()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 表格数组化，在页面加载完之后进行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Page_Loaded(object sender, RoutedEventArgs e)
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

            string html = await NeuOldDriver.API.AAO.RequestInfomation("学生课程表");
            
        }


        /// <summary>
        /// 
        /// </summary>
        private async void ParseClassScheduleHTML()
        {
            string html = await NeuOldDriver.API.AAO.RequestInfomation("学生课程表");  //把学生课程表页面的HTML返回给成string
            for (int j = 4; j < 10; j++)  //行
            {
                for (int i = 2; i < 9; i++)  //列
                {

                    //使用预设编码读入HTML
                    HtmlDocument htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);//加载HTML字符串，如果是文件可以用htmlDocument.Load方法加载

                    //切割路径字符串，加入循环变量，实现课表遍历
                    string str1 = "html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[";
                    string str2 = "]/td[";
                    string str3 = "]";
                    string str = str1 + j + str2 + i + str3;

                    HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(str);
                    //html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[4]/td[2]
                    HtmlNodeCollection collection = htmlNode.ChildNodes;//跟Xpath一样，轻松的定位到相应节点下

                    List<string> datas = new List<string>();//定义1个列表用于保存结果
                    foreach (HtmlNode node in collection)
                    {
                        //去除\r\n以及空格，获取到相应td里面的数据
                        string[] line = node.InnerText.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        //如果符合条件，就加载到对象列表里面
                        if (line.Length == 1)
                            datas.Add(line[0]);


                        if (line.Length == 2)
                            datas.Add(line[0] + line[1]);

                        if (line.Length == 3)
                            datas.Add(line[0] + line[1] + line[2]);

                        if (line.Length == 4)
                            datas.Add(line[0] + line[1] + line[2] + line[3]);

                        if (line.Length == 5)
                            datas.Add(line[0] + line[1] + line[2] + line[3] + line[4]);

                    }

                    string strText = null;
                    string strFSMD = null;
                    int secondClassMark = 0;
                    for (int p = 0; p < datas.Count; p++)
                    {
                        if (char.IsNumber(datas[p][0]))
                        {
                            FSMD fsmd = new FSMD();
                            strFSMD = datas[p];
                            int charNo = 0;
                            for (charNo = 0; (charNo < strFSMD.Length) && (fsmd.stop == 0); charNo++)
                            {
                                fsmd.FSMDistpatch(strFSMD, charNo);
                            }
                            for (int q = 0; q < 20; q++)
                            {
                                if (fsmd.weekMark[q] == 1)
                                {
                                    if (stringss[q][j - 4][i - 2] != null)
                                        stringss[q][j - 4][i - 2] = stringss[q][j - 4][i - 2] + strText;
                                    else
                                        stringss[q][j - 4][i - 2] = strText;
                                }
                            }
                            strText = null;
                            secondClassMark = 1;
                        }
                        else
                        {
                            if ((strText == null) && (secondClassMark == 0))
                                strText = datas[p];
                            else if ((strText == null) && (secondClassMark != 0))
                            {
                                strText = "\n" + datas[p];
                                secondClassMark = 0;
                            }
                            else
                                strText = strText + "\n" + datas[p];
                        }

                    }

                    /*string strText = string.Join("\n", datas.ToArray());
                    if(strText != null)
                        textBlocks[j - 4][i - 2].Text = strText;
                        */

                    /*string strText = null;
                    if (datas[2] != null)
                        strText = datas[2];
                      textBlocks[j - 4][i - 2].Text = strText;  //j为行，i为列
                      */

                }
            }

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

    }

    public class FSMD
    {

        public int state = 0;
        public int stop = 0;
        public int[] weekMark = new int[20];
        int weekNum = 0;
        int loopA = 0;
        int loopMark = 0;

        public void FSMDistpatch(string str, int charNo)
        {
            switch (state)
            {
                case 0:
                    //状态转换
                    if (char.IsNumber(str, charNo))
                        state = 1;
                    //状态转换后功能语句
                    GetFirstNum(str, charNo);
                    break;

                case 1:
                    //状态转换
                    if (char.IsNumber(str, charNo))
                        state = 2;
                    else if (str[charNo] == '-')
                        state = 3;
                    else if (str[charNo] == '.')
                    {
                        stop = 0;
                        state = 6;
                    }
                    else if (str[charNo] == '周')
                    {
                        stop = 1;
                        state = 6;
                    }

                    //状态转换后功能语句
                    switch (state)
                    {
                        case 2:
                            GetSecondNum(str, charNo);
                            break;

                        case 3:
                            GetHyphen(str, charNo);
                            break;

                        case 6:
                            WriteWeekmark(str, charNo);
                            break;

                        default:
                            break;

                    }

                    break;

                case 2:
                    //状态转换
                    if (str[charNo] == '-')
                        state = 3;
                    else if (str[charNo] == '.')
                    {
                        stop = 0;
                        state = 6;
                    }
                    else if (str[charNo] == '周')
                    {
                        stop = 1;
                        state = 6;
                    }

                    //状态转换后功能语句
                    switch (state)
                    {
                        case 3:
                            GetHyphen(str, charNo);
                            break;

                        case 6:
                            WriteWeekmark(str, charNo);
                            break;

                        default:
                            break;
                    }

                    break;

                case 3:
                    //状态转换
                    if (char.IsNumber(str, charNo))
                        state = 4;

                    //状态转换后功能语句
                    switch (state)
                    {
                        case 4:
                            GetFirstNum(str, charNo);
                            break;

                        default:
                            break;
                    }

                    break;

                case 4:
                    //状态转换
                    if (char.IsNumber(str, charNo))
                        state = 5;
                    else if (str[charNo] == '.')
                    {
                        stop = 0;
                        state = 6;
                    }
                    else if (str[charNo] == '周')
                    {
                        stop = 1;
                        state = 6;
                    }
                    //状态转换后功能语句
                    switch (state)
                    {
                        case 5:
                            GetSecondNum(str, charNo);
                            break;

                        case 6:
                            WriteWeekmark(str, charNo);
                            break;

                        default:
                            break;
                    }

                    break;

                case 5:
                    //状态转换
                    if (str[charNo] == '.')
                    {
                        stop = 0;
                        state = 6;
                    }
                    else if (str[charNo] == '周')
                    {
                        stop = 1;
                        state = 6;
                    }
                    //状态转换后功能语句
                    WriteWeekmark(str, charNo);
                    break;

                case 6:
                    //状态转换
                    if (char.IsNumber(str, charNo))
                        state = 1;
                    //状态转换后功能语句
                    GetFirstNum(str, charNo);
                    break;

                default:
                    break;
            }
        }

        void GetFirstNum(string str, int charNo)
        {
            weekNum = int.Parse(str[charNo].ToString());
        }

        void GetSecondNum(string str, int charNo)
        {
            weekNum = weekNum * 10 + int.Parse(str[charNo].ToString());
        }

        void GetHyphen(string str, int charNo)
        {
            loopA = weekNum;
            weekNum = 0;
        }

        void WriteWeekmark(string str, int charNo)
        {
            int loopNum = 0;
            if (loopA != 0)
            {
                for (loopNum = loopA; loopNum <= weekNum; loopNum++)
                {
                    weekMark[loopNum - 1] = 1;
                }
                loopA = 0;
                weekNum = 0;
            }
            else
            {
                weekMark[weekNum - 1] = 1;
                loopA = 0;
                weekNum = 0;
            }
        }
    }
}
