﻿using Poketask.Model;
using Poketask.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Poketask.Entities;
namespace Poketask.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Credits> AllPokemonsCredits { get; } = new();
        public Command GetPokemonsCommand { get; }
        PokemonApiService pokemonApiService;
     
        public MainViewModel(PokemonApiService pokemonApiService)
        {
            Title = "Choose your pokemon!";
            this.pokemonApiService = pokemonApiService;
            GetPokemonsCommand = new Command(async () => await GetPokemonsAsync());
        }

        private async Task GetPokemonsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var apiAllPokemonsCredits = await pokemonApiService.GetPokemons();

                if (AllPokemonsCredits.Count != 0)
                {
                    AllPokemonsCredits.Clear();
                }

                foreach (var pokemonCredits in apiAllPokemonsCredits)
                {
                    pokemonCredits.name = Helpers.Capitalize(pokemonCredits.name);
                    AllPokemonsCredits.Add(pokemonCredits);
                }
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

        public void ExecGetPokemonsAsync()
        {
            Task.Run(GetPokemonsAsync);
        }
    }
}
