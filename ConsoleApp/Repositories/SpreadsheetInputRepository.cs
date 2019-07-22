using ClosedXML.Excel;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleApp.Repositories
{
    public class SpreadsheetInputRepository : IInputRepository
    {
        private readonly string sourceFilePath;
        private readonly int inputColumnIndex;
        private readonly bool hasHeader;

        public SpreadsheetInputRepository(string sourceFilePath, int inputColumnIndex, bool hasHeader)
        {
            this.sourceFilePath = sourceFilePath;
            this.inputColumnIndex = inputColumnIndex;
            this.hasHeader = hasHeader;
        }

        public ReadOnlyCollection<string> ListAll()
        {
            var workbook = new XLWorkbook(sourceFilePath);

            var cells = workbook.Worksheets.First()
                .Columns().Skip(inputColumnIndex).First()
                .Cells().Skip(hasHeader ? 1 : 0);

            return cells.Select(cell => cell.GetString()).ToList().AsReadOnly();
        }
    }
}
