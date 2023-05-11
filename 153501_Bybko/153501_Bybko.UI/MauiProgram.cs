using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Application.Services;
using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Persistence.Repository;
using _153501_Bybko.UI.ViewModels;
using CommunityToolkit.Maui;

namespace _153501_Bybko.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		SetupServices(builder.Services);
		return builder.Build();
	}

	private static void SetupServices(IServiceCollection services)
	{
		// Services
		services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
		services.AddSingleton<IArtistService, ArtistService>();
		services.AddSingleton<ISongService, SongService>();

		// Pages

		// ViewModels
		services.AddSingleton<ArtistsPageViewModel>();
	}
}
