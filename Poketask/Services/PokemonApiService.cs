using Poketask.Entities;
using Poketask.Model;
using System.Net.Http.Json;

namespace Poketask.Services
{
    public class PokemonApiService
    {
        private Constants constants = new Constants();
        List<PokemonCredits> pokemonsCredits = new();
        HttpClient httpClient;

        public PokemonApiService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<PokemonCredits>> GetPokemons()
        {
            //todo cache

            var response = await httpClient.GetAsync(constants.BASE_URL);

            if (response.IsSuccessStatusCode)
            {
                pokemonsCredits = (await response.Content.ReadFromJsonAsync<ApiPokemonCredits>()).results;
            }

            return pokemonsCredits;
        }
    }
}
