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
using NeuOldDriver.Net;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ExamRoom : Page
    {

        TextBlock[][] textBlocks = new TextBlock[10][];

        public ExamRoom()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                textBlocks[i] = new TextBlock[4];
            }

            //行，列
            textBlocks[0][0] = C00;
            textBlocks[0][1] = C01;
            textBlocks[0][2] = C02;
            textBlocks[0][3] = C03;

            textBlocks[1][0] = C10;
            textBlocks[1][1] = C11;
            textBlocks[1][2] = C12;
            textBlocks[1][3] = C13;

            textBlocks[2][0] = C20;
            textBlocks[2][1] = C21;
            textBlocks[2][2] = C22;
            textBlocks[2][3] = C23;

            textBlocks[3][0] = C30;
            textBlocks[3][1] = C31;
            textBlocks[3][2] = C32;
            textBlocks[3][3] = C33;

            textBlocks[4][0] = C40;
            textBlocks[4][1] = C41;
            textBlocks[4][2] = C42;
            textBlocks[4][3] = C43;

            textBlocks[5][0] = C50;
            textBlocks[5][1] = C51;
            textBlocks[5][2] = C52;
            textBlocks[5][3] = C53;

            textBlocks[6][0] = C60;
            textBlocks[6][1] = C61;
            textBlocks[6][2] = C62;
            textBlocks[6][3] = C63;

            textBlocks[7][0] = C70;
            textBlocks[7][1] = C71;
            textBlocks[7][2] = C72;
            textBlocks[7][3] = C73;

            textBlocks[8][0] = C80;
            textBlocks[8][1] = C81;
            textBlocks[8][2] = C82;
            textBlocks[8][3] = C83;

            textBlocks[9][0] = C90;
            textBlocks[9][1] = C91;
            textBlocks[9][2] = C92;
            textBlocks[9][3] = C93;

            ExamRoomHTML();
        }


        private async void ExamRoomHTML()
        {
            string html = await AAOAPI.RequestInfomation("考试日程查询");  //把考试日程查询页面的HTML返回给成string

            int[] selectNum = { 2, 4, 5, 6 };
            for (int row = 2; row < 12; row++)
            {
                for (int column = 0; column < selectNum.Length; column++)
                {
                    //循环改变Xpath表达式路径
                    string xpath1 = "html/body/table/tr[";
                    string xpath2 = "]/td[";
                    string xpath3 = "]";
                    string xpathGradeCheck = xpath1 + row + xpath2 + selectNum[column] + xpath3;

                    List<string> GradeCheckText = HTMLParser.ParseHTML(html, xpathGradeCheck);  //返回当前路径下标签里的文本
                    string GradeCheckStr = string.Join(" ", GradeCheckText.ToArray());
                    GradeCheckStr = GradeCheckStr.Replace("&nbsp;", " ");
                    if (column == 0)
                    {
                        textBlocks[row - 2][column].Text = "     " + GradeCheckStr;
                    }
                    else textBlocks[row - 2][column].Text = GradeCheckStr;

                }
            }
        }
    }

}
