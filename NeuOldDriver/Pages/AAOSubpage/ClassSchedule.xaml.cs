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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace NeuOldDriver.Pages.AAOSubPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ClassSchedule : Page
    {
        TextBlock[][] textBlocks = new TextBlock[6][];

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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            for(int i = 0; i < 6; i++)
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

            checkClassSchedule();
        }


        /// <summary>
        /// 
        /// </summary>
        private void checkClassSchedule()
        {

            string strWebContent = @"
<!DOCTYPE HTML PUBLIC "" -//W3C//DTD HTML 4.01 Transitional//EN"">
<html>
  <head>
    < meta http - equiv = ""Content-Type"" content = ""text/html; charset=GBK"" >
     
         <title> 学生课表查询 </ title >
     
         <link href = ""css/OA_background.css"" rel = stylesheet >
        
            <STYLE>
              fc\:webprint

       {
            behavior: url(include / Print / webprint / webgrid.htc);
                fc\: fc_code

      {
                behavior: url(include / Print / webprint / fc_code.htc);
                }

    </STYLE>
    <script id = ""clientEventHandlersJS"" language = ""javascript"" >
   function doPrint() {
                    window.document.forms[0].action = 'ACTIONQUERYSTUDENTSCHEDULEBYSELF.APPPROCESS?Print=print&Title=学生课表';
                    window.document.forms[0].target = '_blank';
                    window.document.forms[0].submit();
                }
                function doQuery() {
                    window.document.forms[0].action = 'ACTIONQUERYSTUDENTSCHEDULEBYSELF.APPPROCESS';
                    window.document.forms[0].target = '_self';
                    window.document.forms[0].submit();
                }
    </script >
    <style type = ""text/css"" >
 
       < !--
 .style1  {
                color: #FF0000
      }

                -->
          
              </style>
          
            </head>
          
  <body leftmargin = ""0"" topmargin = ""0"" marginwidth = ""0"" marginheight = ""0"" style = ""overflow:hidden"" >
                   
    <table width = ""100%"" height = ""100%"" border = ""0"" cellspacing = ""0"" cellpadding = ""0"" class=tableborder>
      <tr>
        <td background = ""include/Frame/images/SilverBar.gif"" height=""30"" class=""caption"">&nbsp;&nbsp;学生课表查询
        </td>
      </tr>
      <tr>
        <td valign = ""top"" align=""center"" height=""100%"">
          <table width = ""100%"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
            <form name = """" action="""" method=""post"" target="""">
              <tr align = ""left"" valign=""top"">
                <td width = ""100%"" height=""30"" align=""center"">
                  <table width = ""100%"" height=""30"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;姓名:&nbsp;李恒雨&nbsp;&nbsp;&nbsp;&nbsp;学号:&nbsp;20143646&nbsp;</td>
                      <td width = ""270"" align=""right"" nowrap>
                        学年学期&nbsp;
                        <select name = ""YearTermNO"" style=""width:200px"">
                          <option value = ""1"" >
                            2010 - 2011学年第一学期
                            </option>
                          <option value = ""2"" >
                            2010 - 2011学年第二学期
                            </option>
                          <option value = ""3"" >
                            2011 - 2012学年第一学期
                            </option>
                          <option value = ""4"" >
                            2011 - 2012学年第二学期
                            </option>
                          <option value = ""5"" >
                            2012 - 2013学年第一学期
                            </option>
                          <option value = ""6"" >
                            2012 - 2013学年第二学期
                            </option>
                          <option value = ""7"" >
                            2013 - 2014学年第一学期
                            </option>
                          <option value = ""8"" >
                            2013 - 2014学年第二学期
                            </option>
                          <option value = ""9"" >
                            2014 - 2015学年第一学期
                            </option>
                          <option value = ""10"" >
                            2014 - 2015学年第二学期
                            </option>
                          <option value = ""11"" >
                            2015 - 2016学年第一学期
                            </option>
                          <option value = ""12"" >
                            2015 - 2016学年第二学期
                            </option>
                          <option value = ""13"" >
                            2016 - 2017学年第一学期
                            </option>
                          <option value = ""14"" selected>
                            2016-2017学年第二学期
                          </option>
                          <option value = ""15"" >
                            2017 - 2018学年第一学期
                            </option>
                          <option value = ""16"" >
                            2017 - 2018学年第二学期
                            </option>
                        </select>
                      </td>
                      <td width = ""100"" class=""td_a"" align=""right"">
                        <input name = ""bt_Query"" class=""button"" type=""button"" style=""width:80"" onclick=""doQuery()"" value=""查询"">
                      </td>
                      <td width = ""100"" class=""td_a"" align=""center"">
                        <input name = ""bt_Print"" class=""button"" type=""button"" style=""width:80"" onclick=""doPrint()"" value=""打印"">
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </form>
            <tr>
              <td valign = ""top"" align=""center"">
                <table width = ""96%"" height=""100%"" border=""1"" cellpadding=""0"" cellspacing=""0"">
                  <tr>
                    <td align = ""center"" >
                      <div style=""overflow:auto;width:100%;height:100%"">
                        <table border = ""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" frame=""box"">
                          <colgroup>
                            <col style = ""width:30px"" >
                            <col style=""width:14%"">
                            <col style = ""width:14%"" >
                            <col style=""width:14%"">
                            <col style = ""width:14%"" >
                            <col style=""width:14%"">
                            <col style = ""width:14%"" >
                            <col style=""width:14%"">
                          </colgroup>
                          <tr style = ""height:30px"" >
                            <td align=""center"" class=""color-header"" colspan=""8"" class=""color-header"" style=""font-size:14px ; font-weight:700"">东北大学2016-2017学年第二学期学生课表</td>
                          </tr>
                          <tr style = ""height:20px"" >
                            <td colspan=""8"" valign=""bottom"" nowrap style = ""font-size:12px;border-top:none;border-right:none ;border-bottom:.5pt solid #B4E2A4;border-left:none"" >
                               院系:计算机科学与工程学院&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;专业:计算机科学与技术&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;班级:计算机1403&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;学号:20143646&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;姓名:李恒雨
                             </td>
                          </tr>
                          <tr style = ""height:20px"" >
                            <td style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">&nbsp;</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期一MON</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期二TUE</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期三WED</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期四THU</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期五FRI</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期六SAT</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期日SUN</td>
                          </tr>
                          <tr style = ""height:100px"" >
                            <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">
                              1<br style = ""mso-data-placement:same-cell"" >
                              /<br style=""mso-data-placement:same-cell"">
                              2
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">
                              软件工程<br style=""mso-data-placement:same-cell"">
                              高岩<br style= ""mso-data-placement:same-cell"" >
                              信息A112 < br style= ""mso-data-placement:same-cell"" >
                              7 - 17周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" >
                              数据库原理 < br style= ""mso-data-placement:same-cell"" >
                              申德荣 < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              10 - 13周  2节<br style=""mso-data-placement:same-cell"">
                              数据库原理<br style = ""mso-data-placement:same-cell"" >
                              寇月 < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              10 - 13周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" >
                              软件工程 < br style= ""mso-data-placement:same-cell"" >
                              高岩 < br style= ""mso-data-placement:same-cell"" >
                              信息A112 < br style= ""mso-data-placement:same-cell"" >
                              7 - 17周  2节<br style=""mso-data-placement:same-cell"">
                              人工智能<br style = ""mso-data-placement:same-cell"" >
                              马安香 < br style= ""mso-data-placement:same-cell"" >
                              信息A112 < br style= ""mso-data-placement:same-cell"" >
                              1 - 6周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" >
                              网络编程技术 < br style= ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              生命B101 < br style= ""mso-data-placement:same-cell"" >
                              10周  2节<br style=""mso-data-placement:same-cell"">
                              网络编程技术<br style = ""mso-data-placement:same-cell"" >
                              张富 < br style= ""mso-data-placement:same-cell"" >
                              信息B222 < br style= ""mso-data-placement:same-cell"" >
                              11 - 17周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" >
                              信息安全基础 < br style= ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              1 - 2周  2节<br style=""mso-data-placement:same-cell"">
                              人工智能<br style = ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A112 < br style= ""mso-data-placement:same-cell"" >
                              7 - 8周  2节<br style=""mso-data-placement:same-cell"">
                              数据库原理<br style = ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A112 < br style= ""mso-data-placement:same-cell"" >
                              10 - 13周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" >
                              文本智能处理技术 < br style= ""mso-data-placement:same-cell"" >
                              <br style= ""mso-data-placement:same-cell"" >
                              信息A109 < br style= ""mso-data-placement:same-cell"" >
                              10 - 15.17周  3节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" > &nbsp;</td>
                          </tr>
                          <tr style = ""height:100px"" >
                            <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">
                              3<br style = ""mso-data-placement:same-cell"" >
                              /< br style=""mso-data-placement:same-cell"">
                              4
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">
                              操作系统<br style=""mso-data-placement:same-cell"">
                              王大玲<br style= ""mso-data-placement:same-cell"" >
                              信息B103 < br style= ""mso-data-placement:same-cell"" >
                              1 - 14周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" >
                              计算机体系结构 < br style= ""mso-data-placement:same-cell"" >
                              于亚新 < br style= ""mso-data-placement:same-cell"" >
                              信息A314 < br style= ""mso-data-placement:same-cell"" >
                              8 - 17周  2节<br style=""mso-data-placement:same-cell"">
                              信息安全基础<br style = ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              1 - 7周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" >
                              操作系统 < br style= ""mso-data-placement:same-cell"" >
                              王大玲 < br style= ""mso-data-placement:same-cell"" >
                              信息B103 < br style= ""mso-data-placement:same-cell"" >
                              1 - 14周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" >
                              信息安全基础 < br style= ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              1 - 7周  2节<br style=""mso-data-placement:same-cell"">
                              计算机体系结构<br style = ""mso-data-placement:same-cell"" >
                              于亚新 < br style= ""mso-data-placement:same-cell"" >
                              信息A314 < br style= ""mso-data-placement:same-cell"" >
                              8 - 17周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" >
                              数据库原理 < br style= ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              1 - 9周  2节<br style=""mso-data-placement:same-cell"">
                              网络编程技术<br style = ""mso-data-placement:same-cell"" >
                              张富 < br style= ""mso-data-placement:same-cell"" >
                              信息B222 < br style= ""mso-data-placement:same-cell"" >
                              10 - 17周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" >
                              文本智能处理技术 < br style= ""mso-data-placement:same-cell"" >
                              < br style= ""mso-data-placement:same-cell"" >
                              信息A109 < br style= ""mso-data-placement:same-cell"" >
                              10 - 15.17周  3节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" > &nbsp;</td>
                          </tr>
                          <tr style = ""height:100px"" >
                            <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">
                              5<br style = ""mso-data-placement:same-cell"" >
                              /< br style=""mso-data-placement:same-cell"">
                              6
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">
                              人工智能<br style=""mso-data-placement:same-cell"">
                              马安香<br style= ""mso-data-placement:same-cell"" >
                              信息A311 < br style= ""mso-data-placement:same-cell"" >
                              1 - 8周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" > &nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">
                              数据库原理<br style=""mso-data-placement:same-cell"">
                              申德荣<br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              1 - 9周  2节<br style=""mso-data-placement:same-cell"">
                              数据库原理<br style = ""mso-data-placement:same-cell"" >
                              寇月 < br style= ""mso-data-placement:same-cell"" >
                              信息A113 < br style= ""mso-data-placement:same-cell"" >
                              1 - 9周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#EBFFE1"" >
                              软件工程 < br style= ""mso-data-placement:same-cell"" >
                              高岩 < br style= ""mso-data-placement:same-cell"" >
                              信息A112 < br style= ""mso-data-placement:same-cell"" >
                              16 - 17周  2节
                            </td>
                            <td valign = ""top"" style= ""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor= ""#FFFFFF"" > &nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                          </tr>
                          <tr style = ""height:100px"" >
                            <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">
                              7<br style = ""mso-data-placement:same-cell"" >
                              /< br style=""mso-data-placement:same-cell"">
                              8
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">
                              可视化程序设计技术及应用<br style=""mso-data-placement:same-cell"">
                              <br style = ""mso-data-placement:same-cell"" >
                              信息B222 < br style=""mso-data-placement:same-cell"">
                              1-8周  2节
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">
                              可视化程序设计技术及应用<br style=""mso-data-placement:same-cell"">
                              <br style = ""mso-data-placement:same-cell"" >
                              信息B222 < br style=""mso-data-placement:same-cell"">
                              1-8周  2节
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                          </tr>
                          <tr style = ""height:100px"" >
                            <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">
                              9<br style = ""mso-data-placement:same-cell"" >
                              /< br style=""mso-data-placement:same-cell"">
                              10
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">
                              文本智能处理技术<br style=""mso-data-placement:same-cell"">
                              <br style = ""mso-data-placement:same-cell"" >
                              生命B101 < br style=""mso-data-placement:same-cell"">
                              16周  3节
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                          </tr>
                          <tr style = ""height:100px"" >
                            <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">
                              11<br style = ""mso-data-placement:same-cell"" >
                              /< br style=""mso-data-placement:same-cell"">
                              12
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">
                              文本智能处理技术<br style=""mso-data-placement:same-cell"">
                              <br style = ""mso-data-placement:same-cell"" >
                              生命B101 < br style=""mso-data-placement:same-cell"">
                              16周  3节
                            </td>
                            <td valign = ""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
                          </tr>
                          <tr style = ""height:20px"" >
                            <td style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle"" class=""color-header"">&nbsp;</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期一MON</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期二TUE</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期三WED</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期四THU</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期五FRI</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期六SAT</td>
                            <td align = ""center"" nowrap style = ""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" class=""color-header"">星期日SUN</td>
                          </tr>
                        </table>
                      </div>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <!--
  <tr> 
    <td background = ""include/Frame/images/leftbg.gif"" height=""10""></td>
  </tr>
!-->
      <tr>
        <td align = ""right"" height=""20"">
          <a href = ""ACTIONLOGOUT.APPPROCESS"" target=""_parent"">
            <font color = red >
              退出系统
            </font >
          </a >
        </td >
      </tr >
    </table >
  </body >
</html > 
        ";

            int i = 2, j = 4;
            for (; j < 10; j++)
            {
                for (i = 2; i < 9; i++)
                {
                    List<string> datas = new List<string>();//定义1个列表用于保存结果

                    //使用预设编码读入HTML
                    HtmlDocument htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(strWebContent);//加载HTML字符串，如果是文件可以用htmlDocument.Load方法加载

                    //切割路径字符串，加入循环变量，实现课表遍历
                    string str1 = "html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[";
                    string str2 = "]/td[";
                    string str3 = "]";
                    string str = str1 + j + str2 + i + str3;

                    HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(str);
                    //html/body/table/tr[2]/td/table/tr/td/table/tr/td/div/table/tr[4]/td[2]
                    HtmlNodeCollection collection = htmlNode.ChildNodes;//跟Xpath一样，轻松的定位到相应节点下


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

                    string strText = string.Join("\n", datas.ToArray());
                    textBlocks[j - 4][i - 2].Text = strText;

                    /*string strText = null;
                    if (datas[2] != null)
                        strText = datas[2];
                      textBlocks[j - 4][i - 2].Text = strText;*/

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
