namespace ConsoleApp
{
    public class OriginalVsTransformedInput
    {
        public OriginalVsTransformedInput(string original, string transformed)
        {
            Original = original;
            Transformed = transformed;
        }

        public string Original { get; }
        public string Transformed { get; }
    }
}
