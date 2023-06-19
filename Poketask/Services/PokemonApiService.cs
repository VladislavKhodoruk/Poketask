using MonkeyCache.FileStore;
using Poketask.Entities;
using Poketask.Model;
using System.Net.Http.Json;

namespace Poketask.Services
{
    public partial class PokemonApiService
    {
        HttpClient httpClient;
        List<Credits> pokemonsCredits = new();

        public PokemonApiService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Credits>> GetPokemons()
        {
            if(pokemonsCredits.Count > 0)
            {
                return pokemonsCredits;
            }

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                pokemonsCredits = Barrel.Current.Get<List<Credits>>("pokemonsCredits");
            }
            else
            {
                var response = await httpClient.GetAsync(Constants.BASE_URL);

                if (response.IsSuccessStatusCode)
                {
                    pokemonsCredits = (await response.Content.ReadFromJsonAsync<ApiPokemonCredits>()).results;
                    Barrel.Current.Add<List<Credits>>(Constants.POKEMONS_CREDITS_CACHE, pokemonsCredits, Constants.DEFAULT_EXPIRATION_DATE);
                }
            }

            return pokemonsCredits;
        }

        public async Task<Pokemon> GetPokemon(string name, string url)
        {
            Pokemon pokemon = new();

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                pokemon = Barrel.Current.Get<Pokemon>(name);
            }
            else
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                    Barrel.Current.Add(pokemon.name, pokemon, Constants.DEFAULT_EXPIRATION_DATE);
                }
            }
            return pokemon;
        }
    }
}
