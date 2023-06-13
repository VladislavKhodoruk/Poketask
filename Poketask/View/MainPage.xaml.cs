using Poketask.ViewModel;

namespace Poketask;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel pokemonsViewModel)
    {
        InitializeComponent();
        BindingContext = pokemonsViewModel;

        Loaded += (s, e) =>
        {
            pokemonsViewModel.ExecGetPokemonsAsync();
        };
    }
}

