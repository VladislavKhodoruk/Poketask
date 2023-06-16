using Poketask.Model;
using Poketask.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Poketask.Entities;

namespace Poketask.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        PokemonApiService pokemonApiService;
        private List<Credits> allPokemonsCredits { get; set; } = new();
        public ObservableCollection<Credits> CurrentPokemonsCredits { get; } = new();
        public int paginationAmount;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NotAllPokemonsAreShowed))]
        bool allPokemonsAreShowed;
        public bool NotAllPokemonsAreShowed => !allPokemonsAreShowed;
        public Command GetPokemonsCommand { get; }
        public Command ShowMore { get; }
        public MainViewModel(PokemonApiService pokemonApiService)
        {
            Title = "Choose your pokemon!";
            this.pokemonApiService = pokemonApiService;
            GetPokemonsCommand = new Command(async () => await GetPokemonsAsync());
            ShowMore = new Command(async () => await Paginate(Constants.DEFAULT_PAGINATION_STEP));
            paginationAmount = 0;
        }

        private async Task GetPokemonsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                allPokemonsCredits = await pokemonApiService.GetPokemons();

                if (CurrentPokemonsCredits.Count != 0)
                {
                    CurrentPokemonsCredits.Clear();
                }

                await Paginate(Constants.DEFAULT_POKEMONS_AMOUNT);
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

        private async Task Paginate(int step)
        {
            if (AllPokemonsAreShowed)
            {
                return;
            }

            for (int i = paginationAmount; i < paginationAmount + step; i++)
            {
                CurrentPokemonsCredits.Add(allPokemonsCredits[i]);

                if (CurrentPokemonsCredits.Count == allPokemonsCredits.Count)
                {
                    AllPokemonsAreShowed = true;
                    paginationAmount = i;
                    return;
                }
            }

            paginationAmount += step;
            return;
        }
    }
}
