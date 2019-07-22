using ConsoleApp.Repositories;
using ConsoleApp.Transformations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        private const string transformationsFilePath = @"Data\transformations.xlsx";
        private const string inputsFilePath = @"Data\inputs.xlsx";
        private const string resultsFileName = "results.xlsx";

        public static void Main(string[] args)
        {
            var inputs = LoadInputs();
            var pipeline = BuildTransformationPipeline();
            var results = new List<OriginalVsTransformedInput>(inputs.Count);

            foreach (var input in inputs)
            {
                var transformed = pipeline.Run(input);
                results.Add(new OriginalVsTransformedInput(input, transformed));
            }

            Save(results);
        }

        private static TransformationPipeline BuildTransformationPipeline()
        {
            var transformationRepository = new SpreadsheetTransformationRepository(transformationsFilePath, 0, 1, false);
            var transformations = transformationRepository.ListAll();

            var pipeline = new List<ITransformation>
            {
                new RemoveTransformation()
            };

            pipeline.AddRange(transformations);
            pipeline.Add(new SantizeTransformation());
            pipeline.Add(new CaseTransformation());

            return new TransformationPipeline(pipeline.AsReadOnly());
        }

        private static ReadOnlyCollection<string> LoadInputs()
        {
            var inputRepository = new SpreadsheetInputRepository(inputsFilePath, 0, false);
            return inputRepository.ListAll();
        }

        private static void Save(IList<OriginalVsTransformedInput> results)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), resultsFileName);
            var repository = new SpreadsheetTransformedInputRepository(filePath);
            repository.Save(results);
        }
    }
}
