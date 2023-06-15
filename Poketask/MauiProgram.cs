using Microsoft.Extensions.Logging;
using Poketask.Services;
using Poketask.View;
using Poketask.ViewModel;

namespace Poketask;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SpaceMono-Bold.ttf", "SpaceMonoBold");
                fonts.AddFont("SpaceMono-Regular.ttf", "SpaceMonoRegular");
            });

#if DEBUG
        builder.Logging.AddDebug();
		builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddSingleton<PokemonPage>();
        builder.Services.AddTransient<PokemonViewModel>();
        builder.Services.AddTransient<PokemonApiService>();

#endif

        return builder.Build();
	}
}
