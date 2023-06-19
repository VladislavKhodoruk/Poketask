using Poketask.ViewModel;

namespace Poketask.View;

public partial class PokemonPage : ContentPage
{
	public PokemonPage(PokemonViewModel viewModel)
	{

		InitializeComponent();

		BindingContext = viewModel;

        Loaded += (s, e) =>
        {
            viewModel.ExecGetPokemonAsync();
        };
    }

    private async void GoBack(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync($"///{nameof(MainPage)}", true);
    }
}