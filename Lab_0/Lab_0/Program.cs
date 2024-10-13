using Lab_0.Domain;

namespace Lab_0;

internal class Program
{
    static void Main(string[] args)
    {
        JsonReader jsonReader = new JsonReader();
        OutputWriter outputWriter = new OutputWriter(); 
        
        string jsonFilePath = "../../../input/input.json";
        List<AlienSpecies> alienSpeciesList = jsonReader.ReadJson(jsonFilePath);

        if (alienSpeciesList != null)
        {
            List<AlienSpecies> hitchhikerList = new List<AlienSpecies>();
            List<AlienSpecies> marvelList = new List<AlienSpecies>();
            List<AlienSpecies> ringsList = new List<AlienSpecies>();
            List<AlienSpecies> starwarsList = new List<AlienSpecies>();

            foreach (var species in alienSpeciesList)
            {
                string classification = species.Classify();

                if (classification.Contains("Hitchhiker"))
                {
                    hitchhikerList.Add(species);
                }
                else if (classification.Contains("Marvel"))
                {
                    marvelList.Add(species);
                }
                else if (classification.Contains("Rings") || classification.Contains("Lord of the Rings"))
                {
                    ringsList.Add(species);
                }
                else if (classification.Contains("Star Wars"))
                {
                    starwarsList.Add(species);
                }
            }

            outputWriter.WriteToFile("hitchhiker.json", "hitchHiker", hitchhikerList);
            outputWriter.WriteToFile("marvel.json", "marvel", marvelList);
            outputWriter.WriteToFile("rings.json", "rings", ringsList);
            outputWriter.WriteToFile("starwars.json", "starwars", starwarsList);
        }
    }
}