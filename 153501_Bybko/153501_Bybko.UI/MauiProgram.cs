using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Application.Services;
using _153501_Bybko.Domain.Abstractions;
using _153501_Bybko.Domain.Entities;
using _153501_Bybko.Persistence.Data;
using _153501_Bybko.Persistence.Repository;
using _153501_Bybko.UI.Pages;
using _153501_Bybko.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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

        AddDbContext(builder);
        SetupServices(builder.Services);
		SeedData(builder.Services);		      

        return builder.Build();
	}

	private static void SetupServices(IServiceCollection services)
	{
		// Services
		services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
		services.AddSingleton<IArtistService, ArtistService>();
		services.AddSingleton<ISongService, SongService>();

		// Pages
		services.AddSingleton<ArtistsPage>();
        services.AddTransient<SongDetailsPage>();

		// ViewModels
		services.AddSingleton<ArtistsPageViewModel>();
        services.AddTransient<SongDetailsPageViewModel>();
	}

    private static void AddDbContext(MauiAppBuilder builder)
    {
        string settingsStream = "_153501_Bybko.UI.appsettings.json";
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);

        var connStr = builder.Configuration
                               .GetConnectionString("SqliteConnection");
        string dataDirectory = string.Empty;

		#if ANDROID
			dataDirectory = FileSystem.AppDataDirectory + "/";
		#endif
		
		connStr = string.Format(connStr, dataDirectory);

        var options = new DbContextOptionsBuilder<AppDbContext>()
         .UseSqlite(connStr)
         .Options;

        builder.Services.AddSingleton<AppDbContext>((s) =>
                                           new AppDbContext(options));
    }

	public async static void SeedData(IServiceCollection services)
	{
		using var provider = services.BuildServiceProvider();

		var unitOfWork = provider.GetService<IUnitOfWork>();
		await unitOfWork.RemoveDatabaseAsync();
		await unitOfWork.CreateDatabaseAsync();


		// Add artists
		IReadOnlyList<Artist> artists = new List<Artist>()
		{
            new Artist() { Id = 1, Name = "Mitski", Country = "USA/Japan", Genre = "Indie rock" },
            new Artist() { Id = 2, Name = "Tame Impala", Country = "Australia", Genre = "Psychedelic rock" },
            new Artist() { Id = 3, Name = "TWICE", Country = "South Korea", Genre = "K-pop" },
            new Artist() { Id = 4, Name = "Radiohead", Country = "Great Britain", Genre = "Alternative rock" },
        };

        foreach (var artist in artists) 
			await unitOfWork.ArtistRepository.AddAsync(artist);
		await unitOfWork.SaveAllAsync();


        // Add songs
        IReadOnlyList<Song> songs = new List<Song>()
        {
            new Song() { Name = "First Love/Late Spring", Image = "buryme.png", 
                         Album = "Bury Me At Makeout Creek", Top = 1, ArtistId = 1 },
			new Song() { Name = "Francis Forever", Image = "buryme.png", 
                         Album = "Bury Me At Makeout Creek", Top = 9, ArtistId = 1 },
            new Song() { Name = "Crack Baby", Image = "puberty2.png", 
                         Album = "Puberty 2", Top = 17, ArtistId = 1 },
            new Song() { Name = "I Bet on Losing Dogs", Image = "puberty2.png", 
                         Album = "Puberty 2", Top = 5, ArtistId = 1 },
            new Song() { Name = "Nobody", Image = "cowboy.png", 
                         Album = "Be the Cowboy", Top = 25, ArtistId = 1 },
            new Song() { Name = "Me and My Husband", Image = "cowboy.png", 
                         Album = "Be the Cowboy", Top = 29, ArtistId = 1 },
            new Song() { Name = "Washing Machine Heart", Image = "cowboy.png", 
                         Album = "Be the Cowboy", Top = 21, ArtistId = 1 },
            new Song() { Name = "Love Me More", Image = "laurelhell.png", 
                         Album = "Laurel Hell", Top = 13, ArtistId = 1 },
            new Song() { Name = "Stay Soft", Image = "laurelhell.png", 
                         Album = "Laurel Hell", Top = 33, ArtistId = 1 },

            new Song() { Name = "Borderline", Image = "slowrush.png", 
                         Album = "The Slow Rush", Top = 16, ArtistId = 2 },
            new Song() { Name = "One More Hour", Image = "slowrush.png", 
                         Album = "The Slow Rush", Top = 32, ArtistId = 2 },
            new Song() { Name = "New Person, Same Old Mistakes", Image = "currents.png", 
                         Album = "Currents", Top = 4, ArtistId = 2 },
            new Song() { Name = "The Less I Know The Better", Image = "currents.png", 
                         Album = "Currents", Top = 12, ArtistId = 2 },
            new Song() { Name = "Eventually", Image = "currents.png", 
                         Album = "Currents", Top = 8, ArtistId = 2 },
            new Song() { Name = "Let It Happen", Image = "currents.png", 
                         Album = "Currents", Top = 20, ArtistId = 2 },
            new Song() { Name = "Feels Like We Only Go Backwards", Image = "lonerism.png", 
                         Album = "Lonerism", Top = 28, ArtistId = 2 },
            new Song() { Name = "Elephant", Image = "lonerism.png", 
                         Album = "Lonerism", Top = 24, ArtistId = 2 },

            new Song() { Name = "MOONLIGHT SUNRISE", Image = "ready.png", 
                         Album = "READY TO BE", Top = 23, ArtistId = 3 },
            new Song() { Name = "SET ME FREE", Image = "ready.png", 
                         Album = "READY TO BE", Top = 11, ArtistId = 3 },
            new Song() { Name = "Talk that Talk", Image = "between.png", 
                         Album = "BETWEEN 1&2", Top = 19, ArtistId = 3 },
            new Song() { Name = "Doughnut", Image = "doughnut.png", 
                         Album = "Single", Top = 3, ArtistId = 3 },
            new Song() { Name = "Alcohol-Free", Image = "taste.png", 
                         Album = "Taste of Love", Top = 7, ArtistId = 3 },
            new Song() { Name = "I CAN'T STOP ME", Image = "eyeswide.png", 
                         Album = "Eyes Wide Open", Top = 15, ArtistId = 3 },
            new Song() { Name = "Feel Special", Image = "feelspecial.png", 
                         Album = "Feel Special", Top = 27, ArtistId = 3 },
            new Song() { Name = "FANCY", Image = "fancy.png", 
                         Album = "FANCY YOU", Top = 31, ArtistId = 3 },
            
            new Song() { Name = "2 + 2 = 5", Image = "hail.png", 
                         Album = "Hail To the Thief", Top = 18, ArtistId = 4 },
            new Song() { Name = "Exit Music (For A Film)", Image = "computer.png", 
                         Album = "OK Computer", Top = 2, ArtistId = 4 },
            new Song() { Name = "Karma Police", Image = "computer.png", 
                         Album = "OK Computer", Top = 14, ArtistId = 4 },
            new Song() { Name = "No Surprises", Image = "computer.png", 
                         Album = "OK Computer", Top = 6, ArtistId = 4 },
            new Song() { Name = "Hight and Dry", Image = "bends.png", 
                         Album = "The Bends", Top = 30, ArtistId = 4 },
            new Song() { Name = "Fake Plastic Trees", Image = "bends.png", 
                         Album = "The Bends", Top = 22, ArtistId = 4 },
            new Song() { Name = "Just", Image = "bends.png", 
                         Album = "The Bends", Top = 26, ArtistId = 4 },
            new Song() { Name = "My Iron Lung", Image = "bends.png", 
                         Album = "The Bends", Top = 10, ArtistId = 4 }
        };

        foreach (var song in songs)
            await unitOfWork.SongRepository.AddAsync(song);
        await unitOfWork.SaveAllAsync();
    }
}
