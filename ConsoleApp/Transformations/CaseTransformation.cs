using System.Globalization;

namespace ConsoleApp.Transformations
{
    public class CaseTransformation : ITransformation
    {
        public string Apply(string input)
        {
            var info = CultureInfo.CurrentCulture.TextInfo;
            return info.ToTitleCase(input.ToLower());
        }

        public bool IsMatch(string input)
        {
            return true;
        }
    }
}
