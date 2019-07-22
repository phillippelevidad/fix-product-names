namespace ConsoleApp.Transformations
{
    public interface ITransformation
    {
        string Apply(string input);
        bool IsMatch(string input);
    }
}