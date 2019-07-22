using System.Collections.Generic;

namespace ConsoleApp.Repositories
{
    public interface ITransformedInputRepository
    {
        void Save(ICollection<OriginalVsTransformedInput> originalVsTransformedInputs);
    }
}
