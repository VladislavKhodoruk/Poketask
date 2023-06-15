using Poketask.View;

namespace Poketask;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PokemonPage), typeof(PokemonPage));
    }
}
