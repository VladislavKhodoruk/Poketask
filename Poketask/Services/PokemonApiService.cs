using Poketask.Entities;
using Poketask.Model;
using System.Net.Http.Json;

namespace Poketask.Services
{
    public class PokemonApiService
    {
        List<Credits> pokemonsCredits = new();
        Pokemon pokemon = new();
        HttpClient httpClient;

        public PokemonApiService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Credits>> GetPokemons()
        {
            //todo cache

            var response = await httpClient.GetAsync(Constants.BASE_URL);

            if (response.IsSuccessStatusCode)
            {
                pokemonsCredits = (await response.Content.ReadFromJsonAsync<ApiPokemonCredits>()).results;
            }

            return pokemonsCredits;
        }

        public async Task<Pokemon> GetPokemon(string url)
        {
            //todo cache

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                pokemon = (await response.Content.ReadFromJsonAsync<Pokemon>());
            }

            return pokemon;
        }
    }
}
