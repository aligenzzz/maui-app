using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.UI.ViewModels;

namespace _153501_Bybko.UI.Pages;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage(IArtistService artistService, ISongService songService)
	{
		InitializeComponent();
		
		BindingContext = new ArtistsPageViewModel(artistService, songService);
    }
}