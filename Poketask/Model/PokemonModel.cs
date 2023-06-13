namespace Poketask.Model
{
    public class Credits
    {
        public string name { get; set; }
        public string url { get; set; }

    }

    public class ApiPokemonCredits
    {
        public List<Credits> results { get; set; }
    }


    public class Pokemon
    {
        public string name { get; set; }
        public List<PokemonType> types { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public class PokemonType
        {
            public int slot { get; set; }
            public Credits type { get; set; }
        }

    }
}