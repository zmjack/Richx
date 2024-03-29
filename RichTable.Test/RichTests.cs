using NStandard;
using System.Text.RegularExpressions;
using Xunit;

namespace Richx.Test
{
    public class RichTests
    {
        private string SimplifyHtml(string html)
        {
            return html
                .RegexReplace(new Regex(@" style="".+?"""), "")
                .RegexReplace(new Regex(@"<td(| rowspan=""\d+"")>\r\n(.+?)?\r\n</td>"), "<td$1>$2</td>")
                .RegexReplace(new Regex(@"(<td(.+?)/td>)\r\n"), "$1")
                .RegexReplace(new Regex(@"<tr>\r\n<td"), "<tr><td");
        }

        [Fact]
        public void Test1()
        {
            var table = new RichTable();
            table[(0, 0)].Pipe(cell => { cell.Value = "00\r\n10"; });
            table[(0, 1)].Pipe(cell => { cell.Value = "01"; });
            table[(0, 2)].Pipe(cell => { cell.Value = "02"; });
            table[(0, 3)].Pipe(cell => { cell.Value = "03"; });
            table[(0, 4)].Pipe(cell => { cell.Value = "04"; });

            table[(1, 0)].Pipe(cell => { cell.Value = ""; });
            table[(1, 1)].Pipe(cell => { cell.Value = "11\r\n21"; });
            table[(1, 2)].Pipe(cell => { cell.Value = "12"; });
            table[(1, 3)].Pipe(cell => { cell.Value = "13"; });
            table[(1, 4)].Pipe(cell => { cell.Value = "14"; });

            table[(2, 0)].Pipe(cell => { cell.Value = "20"; });
            table[(2, 1)].Pipe(cell => { cell.Value = "11\r\n21"; });
            table[(2, 2)].Pipe(cell => { cell.Value = "22"; });
            table[(2, 3)].Pipe(cell => { cell.Value = "23"; });
            table[(2, 4)].Pipe(cell => { cell.Value = "24"; });

            table[(0, 0), (1, 0)].Merge();
            table[(1, 1), (2, 4)].SmartMerge(0, 1, 2, 3);

            var brush = table.BeginBrush((5, 0));
            brush.PrintLine(new object[] { 1, 2, null, "", 5, 6 });
            foreach (var cell in brush.Area.Cells)
            {
                cell.Style = cell.Style with
                {
                    BackgroundColor = new RgbColor(0x00FFFF),
                };
            }

            foreach (var cell in table.Cells)
            {
                cell.Style = cell.Style with
                {
                    BorderTop = true,
                    BorderBottom = true,
                    BorderLeft = true,
                    BorderRight = true,
                    TextAlign = RichTextAlignment.Center,
                };
            }

            var htmlTable = new HtmlTable(table);
            var html = htmlTable.ToHtml();

            Assert.Equal(@"<table class=""table"" width=""100%"">
<tbody>
<tr><td rowspan=""2"">00<br/>10</td><td>01</td><td>02</td><td>03</td><td>04</td><td></td></tr>
<tr><td rowspan=""2"">11<br/>21</td><td>12</td><td>13</td><td>14</td><td></td></tr>
<tr><td>20</td><td>22</td><td>23</td><td>24</td><td></td></tr>
<tr><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><td></td><td></td><td></td><td></td><td></td><td></td></tr>
<tr><td>1</td><td>2</td><td></td><td></td><td>5</td><td>6</td></tr>
</tbody>
</table>
", SimplifyHtml(html));
        }

    }
}
