using ConsoleApp.Transformations;
using System.Collections.ObjectModel;

namespace ConsoleApp.Repositories
{
    public interface ITransformationRepository
    {
        ReadOnlyCollection<ITransformation> ListAll();
    }
}
