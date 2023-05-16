using _153501_Bybko.UI.ViewModels;

namespace _153501_Bybko.UI.Pages;

public partial class AddArtistPage : ContentPage
{
	public AddArtistPage(AddArtistPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}