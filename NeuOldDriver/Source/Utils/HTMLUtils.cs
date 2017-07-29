using System.Linq;
using System.Collections.Generic;

using HtmlAgilityPack;

namespace NeuOldDriver.Utils {

    public class HTMLUtils {

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

    }
}
