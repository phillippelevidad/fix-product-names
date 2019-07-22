using System.Text.RegularExpressions;

namespace ConsoleApp.Transformations
{
    public class RegexTransformation : ITransformation
    {
        private readonly Regex regex;
        private readonly string substitution;

        public RegexTransformation(Regex regex, string substitution)
        {
            this.regex = regex;
            this.substitution = substitution;
        }

        public static RegexTransformation Create(string regexPattern, string substitution)
        {
            var regex = new Regex(regexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            substitution = substitution.Trim() + " ";
            return new RegexTransformation(regex, substitution);
        }

        public bool IsMatch(string input)
        {
            return regex.IsMatch(input);
        }

        public string Apply(string input)
        {
            return regex.Replace(input, substitution);
        }
    }
}
