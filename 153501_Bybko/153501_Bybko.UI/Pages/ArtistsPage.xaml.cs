using _153501_Bybko.UI.ViewModels;

namespace _153501_Bybko.UI.Pages;

public partial class ArtistsPage : ContentPage
{
	public ArtistsPage(ArtistsPageViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
    }
}