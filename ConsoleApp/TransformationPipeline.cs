using ConsoleApp.Transformations;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class TransformationPipeline
    {
        private readonly IEnumerable<ITransformation> transformations;

        public TransformationPipeline(IEnumerable<ITransformation> transformations)
        {
            this.transformations = transformations;
        }

        public string Run(string input)
        {
            foreach (var t in transformations)
                if (t.IsMatch(input))
                    input = t.Apply(input);

            return input;
        }
    }
}
