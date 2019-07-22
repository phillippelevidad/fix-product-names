using System.Collections.ObjectModel;

namespace ConsoleApp.Repositories
{
    public interface IInputRepository
    {
        ReadOnlyCollection<string> ListAll();
    }
}
