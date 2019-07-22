using System;

namespace ConsoleApp.Transformations
{
    public class RemoveTransformation : ITransformation
    {
        public string Apply(string input)
        {
            return "";
        }

        public bool IsMatch(string input)
        {
            return
                input.Contains("F.LINHA", StringComparison.OrdinalIgnoreCase) ||
                input.Contains("SDLQ", StringComparison.OrdinalIgnoreCase);
        }
    }
}
