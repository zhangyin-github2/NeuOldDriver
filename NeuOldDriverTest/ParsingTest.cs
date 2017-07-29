using System.Collections.Generic;

using NeuOldDriver.Models;
using NeuOldDriver.Extensions;
using NeuOldDriver.ViewModels;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace NeuOldDriverTest {

    [TestClass]
    public class ParsingTest {

        private const string testSource = @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"">
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=GBK"">
<title>学生课表查询</title>
</head>
<body leftmargin=""0"" topmargin=""0"" marginwidth=""0"" marginheight=""0"" style=""overflow:hidden"">
<table width=""100%"" height=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=tableborder>
  <tr> 
    <td  background=""include/Frame/images/SilverBar.gif"" height=""30"" class=""caption"">&nbsp;&nbsp;
学生课表查询
</td>
  </tr>
  <tr> 
    <td valign=""top"" align=""center"" height=""100%"">
<table width=""100%"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
 <form name="""" action="""" method=""post"" target="""">
  <tr align=""left"" valign=""top"">
    <td width=""100%"" height=""30"" align=""center"">
    <table width=""100%"" height=""30"" border=""0"" cellpadding=""0"" cellspacing=""0"">
          <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;姓名:&nbsp;黄文睿&nbsp;&nbsp;&nbsp;&nbsp;学号:&nbsp;20141874&nbsp;</td>
            <td width=""270"" align=""right"" nowrap>学年学期&nbsp;
              <select name=""YearTermNO"" style=""width:200px"">
            <option value=""1"">2010-2011学年第一学期</option><option value=""2"">2010-2011学年第二学期</option><option value=""3"">2011-2012学年第一学期</option><option value=""4"">2011-2012学年第二学期</option><option value=""5"">2012-2013学年第一学期</option><option value=""6"">2012-2013学年第二学期</option><option value=""7"">2013-2014学年第一学期</option><option value=""8"">2013-2014学年第二学期</option><option value=""9"">2014-2015学年第一学期</option><option value=""10"">2014-2015学年第二学期</option><option value=""11"">2015-2016学年第一学期</option><option value=""12"">2015-2016学年第二学期</option><option value=""13"">2016-2017学年第一学期</option><option value=""14"" selected>2016-2017学年第二学期</option><option value=""15"">2017-2018学年第一学期</option><option value=""16"">2017-2018学年第二学期</option></select></td>
            <td width=""100"" class=""td_a"" align=""right""><input name=""bt_Query"" class=""button"" type=""button"" style=""width:80"" onclick=""doQuery()"" value=""查询""></td>
            <td width=""100"" class=""td_a"" align=""center""><input name=""bt_Print"" class=""button"" type=""button"" style=""width:80"" onclick=""doPrint()"" value=""打印""></td>
          </tr>
        </table>
</td>
  </tr>
</form>
 <tr><td valign=""top"" align=""center""><table width=""96%"" height=""100%"" border=""1"" cellpadding=""0"" cellspacing=""0""><tr><td align=""center"">
    <div style=""overflow:auto;width:100%;height:100%"">
<table border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" frame=""box"">
<colgroup>
   <col style=""width:30px"">
   <col style=""width:14%"">
   <col style=""width:14%"">
   <col style=""width:14%"">
   <col style=""width:14%"">
   <col style=""width:14%"">
   <col style=""width:14%"">
   <col style=""width:14%"">
</colgroup>
      <tr style=""height:30px"">
        <td align=""center""  class=""color-header""  colspan=""8"" class=""color-header""  style=""font-size:14px ; font-weight:700"">东北大学2016-2017学年第二学期学生课表</td>
      </tr>
      <tr style=""height:20px"">
        <td colspan=""8"" valign=""bottom"" nowrap style=""font-size:12px;border-top:none;border-right:none ;border-bottom:.5pt solid #B4E2A4;border-left:none"">院系:计算机科学与工程学院&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;专业:计算机科学与技术&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;班级:计算机1403&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;学号:20141874&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;姓名:黄文睿</td>
      </tr>
      <tr style=""height:20px"">
        <td style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" >&nbsp;</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期一MON</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期二TUE</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期三WED</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期四THU</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期五FRI</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期六SAT</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期日SUN</td>
      </tr>
      <tr style=""height:100px"">
        <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" > 1<br style=""mso-data-placement:same-cell"">/<br style=""mso-data-placement:same-cell""> 2</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">软件工程<br style=""mso-data-placement:same-cell"">高岩<br style=""mso-data-placement:same-cell"">信息A112<br style=""mso-data-placement:same-cell"">7-17周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">数据库原理<br style=""mso-data-placement:same-cell"">申德荣<br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">10-13周  2节<br style=""mso-data-placement:same-cell"">数据库原理<br style=""mso-data-placement:same-cell"">寇月<br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">10-13周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">软件工程<br style=""mso-data-placement:same-cell"">高岩<br style=""mso-data-placement:same-cell"">信息A112<br style=""mso-data-placement:same-cell"">7-17周  2节<br style=""mso-data-placement:same-cell"">人工智能<br style=""mso-data-placement:same-cell"">马安香<br style=""mso-data-placement:same-cell"">信息A112<br style=""mso-data-placement:same-cell"">1-6周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">网络编程技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">生命B101<br style=""mso-data-placement:same-cell"">10周  2节<br style=""mso-data-placement:same-cell"">网络编程技术<br style=""mso-data-placement:same-cell"">张富<br style=""mso-data-placement:same-cell"">信息B222<br style=""mso-data-placement:same-cell"">11-17周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">信息安全基础<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">1-2周  2节<br style=""mso-data-placement:same-cell"">人工智能<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A112<br style=""mso-data-placement:same-cell"">7-8周  2节<br style=""mso-data-placement:same-cell"">数据库原理<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A112<br style=""mso-data-placement:same-cell"">10-13周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">文本智能处理技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A109<br style=""mso-data-placement:same-cell"">10-15.17周  3节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
      </tr>
      <tr style=""height:100px"">
        <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" > 3<br style=""mso-data-placement:same-cell"">/<br style=""mso-data-placement:same-cell""> 4</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">操作系统<br style=""mso-data-placement:same-cell"">王大玲<br style=""mso-data-placement:same-cell"">信息B103<br style=""mso-data-placement:same-cell"">1-14周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">计算机体系结构<br style=""mso-data-placement:same-cell"">于亚新<br style=""mso-data-placement:same-cell"">信息A314<br style=""mso-data-placement:same-cell"">8-17周  2节<br style=""mso-data-placement:same-cell"">信息安全基础<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">1-7周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">操作系统<br style=""mso-data-placement:same-cell"">王大玲<br style=""mso-data-placement:same-cell"">信息B103<br style=""mso-data-placement:same-cell"">1-14周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">信息安全基础<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">1-7周  2节<br style=""mso-data-placement:same-cell"">计算机体系结构<br style=""mso-data-placement:same-cell"">于亚新<br style=""mso-data-placement:same-cell"">信息A314<br style=""mso-data-placement:same-cell"">8-17周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">数据库原理<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">1-9周  2节<br style=""mso-data-placement:same-cell"">网络编程技术<br style=""mso-data-placement:same-cell"">张富<br style=""mso-data-placement:same-cell"">信息B222<br style=""mso-data-placement:same-cell"">10-17周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">文本智能处理技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A109<br style=""mso-data-placement:same-cell"">10-15.17周  3节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
      </tr>
      <tr style=""height:100px"">
        <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" > 5<br style=""mso-data-placement:same-cell"">/<br style=""mso-data-placement:same-cell""> 6</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">人工智能<br style=""mso-data-placement:same-cell"">马安香<br style=""mso-data-placement:same-cell"">信息A311<br style=""mso-data-placement:same-cell"">1-8周  2节<br style=""mso-data-placement:same-cell"">嵌入式系统及其应用<br style=""mso-data-placement:same-cell"">刘辉林<br style=""mso-data-placement:same-cell"">信息A311<br style=""mso-data-placement:same-cell"">9-15周  2节<br style=""mso-data-placement:same-cell"">嵌入式系统及其应用<br style=""mso-data-placement:same-cell"">王国仁<br style=""mso-data-placement:same-cell"">信息A311<br style=""mso-data-placement:same-cell"">9-15周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">数据库原理<br style=""mso-data-placement:same-cell"">申德荣<br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">1-9周  2节<br style=""mso-data-placement:same-cell"">数据库原理<br style=""mso-data-placement:same-cell"">寇月<br style=""mso-data-placement:same-cell"">信息A113<br style=""mso-data-placement:same-cell"">1-9周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">软件工程<br style=""mso-data-placement:same-cell"">高岩<br style=""mso-data-placement:same-cell"">信息A112<br style=""mso-data-placement:same-cell"">16-17周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
      </tr>
      <tr style=""height:100px"">
        <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" > 7<br style=""mso-data-placement:same-cell"">/<br style=""mso-data-placement:same-cell""> 8</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">可视化程序设计技术及应用<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息B222<br style=""mso-data-placement:same-cell"">1-8周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">软件建模技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A308<br style=""mso-data-placement:same-cell"">1-6周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">嵌入式系统及其应用<br style=""mso-data-placement:same-cell"">刘辉林<br style=""mso-data-placement:same-cell"">信息A311<br style=""mso-data-placement:same-cell"">9-17周  2节<br style=""mso-data-placement:same-cell"">可视化程序设计技术及应用<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息B222<br style=""mso-data-placement:same-cell"">1-8周  2节<br style=""mso-data-placement:same-cell"">嵌入式系统及其应用<br style=""mso-data-placement:same-cell"">王国仁<br style=""mso-data-placement:same-cell"">信息A311<br style=""mso-data-placement:same-cell"">9-17周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">软件建模技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">信息A308<br style=""mso-data-placement:same-cell"">1-6周  2节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
      </tr>
      <tr style=""height:100px"">
        <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" > 9<br style=""mso-data-placement:same-cell"">/<br style=""mso-data-placement:same-cell"">10</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">文本智能处理技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">生命B101<br style=""mso-data-placement:same-cell"">16周  3节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
      </tr>
      <tr style=""height:100px"">
        <td align=""center"" valign=""middle"" style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" >11<br style=""mso-data-placement:same-cell"">/<br style=""mso-data-placement:same-cell"">12</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#EBFFE1"">文本智能处理技术<br style=""mso-data-placement:same-cell""><br style=""mso-data-placement:same-cell"">生命B101<br style=""mso-data-placement:same-cell"">16周  3节</td>
        <td valign=""top"" style=""font-size:10px;border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal"" bgcolor=""#FFFFFF"">&nbsp;</td>
      </tr>
      <tr style=""height:20px"">
        <td style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:.5pt solid #B4E2A4;text-align:center;vertical-align:middle""  class=""color-header"" >&nbsp;</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期一MON</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期二TUE</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期三WED</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期四THU</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期五FRI</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期六SAT</td>
        <td align=""center"" nowrap style=""border-top:none;border-right:.5pt solid #B4E2A4;border-bottom:.5pt solid #B4E2A4;border-left:none;white-space:normal""  class=""color-header"" >星期日SUN</td>
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
  <tr> 
  <td align=""right"" height=""20"">
   <a href=""ACTIONLOGOUT.APPPROCESS"" target=""_parent""><font color=red >退出系统</font> </a>
  </td>
  </tr>
</table>
</body>
</html>
";
        [TestMethod]
        public void ParseWeeksTest() {
            var result = Course.ParseWeekNumbers("1.2-3.6.8-9.15-16.20周 4节");
            foreach (var i in new[] { 1, 2, 3, 6, 8, 9, 15, 16, 20 })
                Assert.IsTrue(result[i - 1]);
            foreach (var i in new[] { 4, 5, 7, 10, 11, 12, 13, 14, 17, 18, 19 })
                Assert.IsFalse(result[i - 1]);
        }

        [TestMethod]
        public void ParseCourseTest() {
            var test1 = Course.Deserialize(new List<string>());
            Assert.IsTrue(test1.Count == 0);

            var test2 = Course.Deserialize(new List<string>() {
                "数据库原理", "申德荣", "信息A113", "10-13周 2节",
                "数据库原理", "信息A113", "10-13周 2节"
            });
            Assert.IsTrue(test2.Count == 2);
            Assert.AreEqual("数据库原理", test2[0].name);
            Assert.AreEqual("申德荣", test2[0].teacher);
            Assert.AreEqual("信息A113", test2[0].location);
            Assert.AreEqual("信息A113", test2[1].location);
            Assert.IsTrue(test2[0].weeks.Same(test2[1].weeks));
            for (var i = 9; i < 13; ++i)
                Assert.IsTrue(test2[0].weeks[i]);
        }

        [TestMethod]
        public void ParsedResultTest() {
            var obj = new CourseTableViewModel();
            obj.LoadCourses(testSource);
            Assert.AreEqual("东北大学2016-2017学年第二学期学生课表", obj.Term);
            Assert.AreEqual("院系:计算机科学与工程学院 专业:计算机科学与技术 班级:计算机1403 学号:20141874 姓名:黄文睿", obj.StudentInfo);
        }
    }
}
