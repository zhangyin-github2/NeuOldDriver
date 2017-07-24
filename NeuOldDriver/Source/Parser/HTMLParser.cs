using System;
using System.Collections.Generic;

using HtmlAgilityPack;

namespace NeuOldDriver.Source.Parser {
    class HTMLParser
    {
        public static List<string> ParseHTML(string html, string xpath)
        {
            //使用预设编码读入HTML
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);//加载HTML字符串，如果是文件可以用htmlDocument.Load方法加载

            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(xpath);  //跟Xpath一样，轻松的定位到相应节点下
            HtmlNodeCollection collection = htmlNode.ChildNodes;

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

            return datas;

        }
    }
}
