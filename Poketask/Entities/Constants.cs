namespace Poketask.Entities
{
    public class Constants
    {
        public static string BASE_URL = "https://pokeapi.co/api/v2/pokemon";
        public static string POKEMONS_CREDITS_CACHE = "pokemonsCredits";

        public static int DEFAULT_POKEMONS_AMOUNT = 10;
        public static int DEFAULT_PAGINATION_STEP = 5;

        public static TimeSpan DEFAULT_EXPIRATION_DATE = TimeSpan.FromDays(5);

    }
}