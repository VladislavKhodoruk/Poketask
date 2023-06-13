namespace Poketask.Model
{
    public class PokemonCredits
    {
        public string name { get; set; }
        public string url { get; set; }

    }

    public class ApiPokemonCredits
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PokemonCredits> results { get; set; }
    }
}
