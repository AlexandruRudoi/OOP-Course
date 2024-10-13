using System;
using Lab_0.Domain;

namespace Lab_0;

internal class Program
{
    static void Main(string[] args)
    {
        JsonReader jsonReader = new JsonReader();
        string jsonFilePath = "../../../input/input.json";
        List<AlienSpecies> alienSpeciesList = jsonReader.ReadJson(jsonFilePath);

        if (alienSpeciesList != null)
        {
            foreach (var species in alienSpeciesList)
            {
                species.PrintSpecies();
                Console.WriteLine($"Classified as: {species.Classify()}");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}