using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Repositories
{
    public class SpreadsheetTransformedInputRepository : ITransformedInputRepository
    {
        private readonly string targetFilePath;

        public SpreadsheetTransformedInputRepository(string targetFilePath)
        {
            this.targetFilePath = targetFilePath;
        }

        public void Save(ICollection<OriginalVsTransformedInput> originalVsTransformedInputs)
        {
            var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add("Transformed Inputs");

            for (int entryIndex = 0; entryIndex < originalVsTransformedInputs.Count; entryIndex++)
            {
                var entry = originalVsTransformedInputs.ElementAt(entryIndex);

                var row = entryIndex + 1;
                sheet.Cell(row, 1).SetValue(entry.Original);
                sheet.Cell(row, 2).SetValue(entry.Transformed);
            }

            workbook.SaveAs(targetFilePath);
        }
    }
}
