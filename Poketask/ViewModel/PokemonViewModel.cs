using CommunityToolkit.Mvvm.ComponentModel;
using Poketask.Model;
using Poketask.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Poketask.ViewModel
{
    [QueryProperty(nameof(PokemonCredits), "PokemonCredits")]
    public partial class PokemonViewModel : BaseViewModel
    {

        [ObservableProperty]
        Pokemon pokemon;

        public Command GetPokemonCommand { get; }
        PokemonApiService pokemonApiService;

        [ObservableProperty]
        Credits pokemonCredits;

        public PokemonViewModel(PokemonApiService pokemonApiService)
        {
            this.pokemonApiService = pokemonApiService;
            GetPokemonCommand = new Command(async () => await GetPokemonAsync());

            Title = GetTitleByConnectionStatus(Connectivity.NetworkAccess == NetworkAccess.Internet);
            Connectivity.ConnectivityChanged += (sender, e) =>
            {
                Title = GetTitleByConnectionStatus(e.NetworkAccess == NetworkAccess.Internet);
            };
        }

        private string GetTitleByConnectionStatus(bool connectionStatus)
        {
            if (connectionStatus) return "Pokemon info";

            return "You're offline";
        }

        async Task GetPokemonAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var apiPokemon = await pokemonApiService.GetPokemon(pokemonCredits.name, pokemonCredits.url);
                if (apiPokemon == null)
                {
                    NoData = true;
                    return;
                }

                Pokemon = apiPokemon;
                NoData = false;
            }
            catch (Exception exp)
            {
                Debug.WriteLine($"Error: {exp.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", exp.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void ExecGetPokemonAsync()
        {
            Task.Run(() => GetPokemonAsync());
        }
    }
}
