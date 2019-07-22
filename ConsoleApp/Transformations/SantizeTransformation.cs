using System.Text.RegularExpressions;

namespace ConsoleApp.Transformations
{
    public class SantizeTransformation : ITransformation
    {
        private static readonly Regex doubleSpaces = new Regex(@"\s+", RegexOptions.Compiled);

        public string Apply(string input)
        {
            input = doubleSpaces.Replace(input, " ");
            return input.Trim();
        }

        public bool IsMatch(string input)
        {
            return true;
        }
    }
}
