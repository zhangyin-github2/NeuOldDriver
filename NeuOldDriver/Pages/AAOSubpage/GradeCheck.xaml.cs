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
using NeuOldDriver.Source.Parser;
using NeuOldDriver.Net;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage
{

    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GradeCheck : Page
    {
        TextBlock[][] textBlocks = new TextBlock[20][];

        public GradeCheck()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                textBlocks[i] = new TextBlock[6];
            }

            //行，列
            textBlocks[0][0] = C00;
            textBlocks[0][1] = C01;
            textBlocks[0][2] = C02;
            textBlocks[0][3] = C03;
            textBlocks[0][4] = C04;
            textBlocks[0][5] = C05;

            textBlocks[1][0] = C10;
            textBlocks[1][1] = C11;
            textBlocks[1][2] = C12;
            textBlocks[1][3] = C13;
            textBlocks[1][4] = C14;
            textBlocks[1][5] = C15;

            textBlocks[2][0] = C20;
            textBlocks[2][1] = C21;
            textBlocks[2][2] = C22;
            textBlocks[2][3] = C23;
            textBlocks[2][4] = C24;
            textBlocks[2][5] = C25;

            textBlocks[3][0] = C30;
            textBlocks[3][1] = C31;
            textBlocks[3][2] = C32;
            textBlocks[3][3] = C33;
            textBlocks[3][4] = C34;
            textBlocks[3][5] = C35;

            textBlocks[4][0] = C40;
            textBlocks[4][1] = C41;
            textBlocks[4][2] = C42;
            textBlocks[4][3] = C43;
            textBlocks[4][4] = C44;
            textBlocks[4][5] = C45;

            textBlocks[5][0] = C50;
            textBlocks[5][1] = C51;
            textBlocks[5][2] = C52;
            textBlocks[5][3] = C53;
            textBlocks[5][4] = C54;
            textBlocks[5][5] = C55;

            textBlocks[6][0] = C60;
            textBlocks[6][1] = C61;
            textBlocks[6][2] = C62;
            textBlocks[6][3] = C63;
            textBlocks[6][4] = C64;
            textBlocks[6][5] = C65;

            textBlocks[7][0] = C70;
            textBlocks[7][1] = C71;
            textBlocks[7][2] = C72;
            textBlocks[7][3] = C73;
            textBlocks[7][4] = C74;
            textBlocks[7][5] = C75;

            textBlocks[8][0] = C80;
            textBlocks[8][1] = C81;
            textBlocks[8][2] = C82;
            textBlocks[8][3] = C83;
            textBlocks[8][4] = C84;
            textBlocks[8][5] = C85;

            textBlocks[9][0] = C90;
            textBlocks[9][1] = C91;
            textBlocks[9][2] = C92;
            textBlocks[9][3] = C93;
            textBlocks[9][4] = C94;
            textBlocks[9][5] = C95;

            textBlocks[10][0] = C100;
            textBlocks[10][1] = C101;
            textBlocks[10][2] = C102;
            textBlocks[10][3] = C103;
            textBlocks[10][4] = C104;
            textBlocks[10][5] = C105;

            textBlocks[11][0] = C110;
            textBlocks[11][1] = C111;
            textBlocks[11][2] = C112;
            textBlocks[11][3] = C113;
            textBlocks[11][4] = C114;
            textBlocks[11][5] = C115;

            textBlocks[12][0] = C120;
            textBlocks[12][1] = C121;
            textBlocks[12][2] = C122;
            textBlocks[12][3] = C123;
            textBlocks[12][4] = C124;
            textBlocks[12][5] = C125;

            textBlocks[13][0] = C130;
            textBlocks[13][1] = C131;
            textBlocks[13][2] = C132;
            textBlocks[13][3] = C133;
            textBlocks[13][4] = C134;
            textBlocks[13][5] = C135;

            textBlocks[14][0] = C140;
            textBlocks[14][1] = C141;
            textBlocks[14][2] = C142;
            textBlocks[14][3] = C143;
            textBlocks[14][4] = C144;
            textBlocks[14][5] = C145;

            textBlocks[15][0] = C150;
            textBlocks[15][1] = C151;
            textBlocks[15][2] = C152;
            textBlocks[15][3] = C153;
            textBlocks[15][4] = C154;
            textBlocks[15][5] = C155;

            textBlocks[16][0] = C160;
            textBlocks[16][1] = C161;
            textBlocks[16][2] = C162;
            textBlocks[16][3] = C163;
            textBlocks[16][4] = C164;
            textBlocks[16][5] = C165;

            textBlocks[17][0] = C170;
            textBlocks[17][1] = C171;
            textBlocks[17][2] = C172;
            textBlocks[17][3] = C173;
            textBlocks[17][4] = C174;
            textBlocks[17][5] = C175;

            textBlocks[18][0] = C180;
            textBlocks[18][1] = C181;
            textBlocks[18][2] = C182;
            textBlocks[18][3] = C183;
            textBlocks[18][4] = C184;
            textBlocks[18][5] = C185;

            textBlocks[19][0] = C190;
            textBlocks[19][1] = C191;
            textBlocks[19][2] = C192;
            textBlocks[19][3] = C193;
            textBlocks[19][4] = C194;
            textBlocks[19][5] = C195;

            ParseGradeCheckHTML();
        }

        private async void ParseGradeCheckHTML()
        {
            string html = await AAOAPI.RequestInfomation("学生成绩查询");  //把学生成绩查询页面的HTML返回给成string

            //学生信息
            string xpathStudentInformation = "html/body/table/tr[2]/td/form/table/tr/td/table/tr/td";
            List<string> StudentInformationText = HTMLParser.ParseHTML(html, xpathStudentInformation);
            string str = string.Join(" ", StudentInformationText.ToArray());
            str = str.Replace("&nbsp;", " ");
            StudentInformation.Text = str;

            //课程成绩
            //先查询课程数量
            string xpathClassNum = "html/body/table/tr[2]/td/form/table/tr/td/table/tr/td";
            List<string> ClassNumText = HTMLParser.ParseHTML(html, xpathClassNum);
            int ClassNum = 0;
            for(int p = 0; p < ClassNumText[0].Length; p++)
            {
                if(char.IsNumber(str, p))
                    ClassNum = ClassNum * 10 + int.Parse(ClassNumText[0][p].ToString());
            }

            //再按课程数量确定Xpath表达式路径循环
            int[] selectNum = { 3, 6, 8, 9, 10, 11 };
            for (int i = 1; i < ClassNum + 1; i++)
            {
                for(int j = 0; j < selectNum.Length; j++)
                {
                    //循环改变Xpath表达式路径
                    //html/body/table/tr[2]/td/form/table/tr[2]/td/div/table/tr[2]/td[3][6][8][9][10][11]
                    string xpath1 = "html/body/table/tr[2]/td/form/table/tr[2]/td/div/table/tr[";
                    string xpath2 = "]/td[";
                    string xpath3 = "]";
                    string xpathGradeCheck = xpath1 + i + xpath2 + selectNum[j] + xpath3;

                    List<string> GradeCheckText = HTMLParser.ParseHTML(html, xpathGradeCheck);  //返回当前路径下标签里的文本
                    textBlocks[i-1][j].Text = string.Join(" ", GradeCheckText.ToArray());

                }
            }
        }
    }
}
