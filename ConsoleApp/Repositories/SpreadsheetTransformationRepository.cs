using ClosedXML.Excel;
using ConsoleApp.Transformations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleApp.Repositories
{
    public class SpreadsheetTransformationRepository : ITransformationRepository
    {
        private readonly string filePath;
        private readonly int patternColumnIndex;
        private readonly int substitutionColumnIndex;
        private readonly bool hasHeader;

        public SpreadsheetTransformationRepository(string filePath, int patternColumnIndex, int substitutionColumnIndex, bool hasHeader)
        {
            this.filePath = filePath;
            this.patternColumnIndex = patternColumnIndex;
            this.substitutionColumnIndex = substitutionColumnIndex;
            this.hasHeader = hasHeader;
        }

        public ReadOnlyCollection<ITransformation> ListAll()
        {
            return ReadAllLines()
                .Select(line => RegexTransformation.Create(line.Key, line.Value) as ITransformation)
                .ToList().AsReadOnly();
        }

        private IEnumerable<KeyValuePair<string, string>> ReadAllLines()
        {
            var workbook = new XLWorkbook(filePath);
            var sheet = workbook.Worksheets.First();

            var patternColumn = sheet.Columns().Skip(patternColumnIndex).First();
            var substitutionColumn = sheet.Columns().Skip(substitutionColumnIndex).First();

            var rowIndex = hasHeader ? 1 : 0;
            var patterns = patternColumn.Cells().Skip(rowIndex).Select(cell => cell.GetString()).ToArray();
            var substitutions = substitutionColumn.Cells().Skip(rowIndex).Select(cell => cell.GetString()).ToArray();

            var pair = new List<KeyValuePair<string, string>>(patterns.Length);

            for (int entryIndex = 0; entryIndex < patterns.Length; entryIndex++)
            {
                pair.Add(new KeyValuePair<string, string>(
                    patterns[entryIndex],
                    substitutions[entryIndex]));
            }

            return pair;
        }
    }
}
