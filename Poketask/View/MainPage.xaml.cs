using Poketask.Model;
using Poketask.View;
using Poketask.ViewModel;

namespace Poketask;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        Loaded += (s, e) =>
        {
            viewModel.ExecGetPokemonsAsync();
        };
    }

    private async void PokemonTapped(object sender, EventArgs e)
    {
        var pokemonCredits = ((VisualElement)sender).BindingContext as Credits;

        if(pokemonCredits == null)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(PokemonPage), true, new Dictionary<string, object>
        {
            {"PokemonCredits", pokemonCredits}
        });
    }
}

