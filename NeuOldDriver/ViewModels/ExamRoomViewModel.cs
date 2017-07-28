using System;
using System.Linq;

using NeuOldDriver.Utils;
using NeuOldDriver.Models;

using HtmlAgilityPack;

namespace NeuOldDriver.ViewModels {

    public class ExamRoomViewModel : ViewModelBase {

        private ExamRoom[] rooms;

        public ExamRoom[] Rooms {
            get { return rooms; }
        }

        public void LoadRoom(string html) {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            var container = document.DocumentNode.SelectSingleNode("html/body/table");
            rooms = new ExamRoom[10];

            for (var row = 2; row < 12; ++row)
                rooms[row - 2] = ParseRoom(container, row);
        }

        private static ExamRoom ParseRoom(HtmlNode container, int row) {
            return ExamRoom.Deserialize((new[] { 2, 4, 5, 6 }).Select((col) => {
                var parsed = HTMLUtils.ParseHTML(container, String.Format("tr[{0}]/td[{1}]", row, col));
                return parsed.FirstOrDefault()?.Replace("&nbsp;", "");
            }));
        }

    }
}
