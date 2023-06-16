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
        public Sprites sprites { get; set; }
    }
    public class PokemonType
    {
        public Credits type { get; set; }
        public string image { get; set; }
    }

    public class Sprites
    {
        public Other other { get; set; }
    }

    public class Other
    {
        public Home home { get; set; }
    }

    public class Home
    {
        public string front_shiny { get; set; }
    }
}