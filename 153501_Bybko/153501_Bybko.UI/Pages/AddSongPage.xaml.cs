using _153501_Bybko.UI.ViewModels;

namespace _153501_Bybko.UI.Pages;

public partial class AddSongPage : ContentPage
{
	public AddSongPage(AddSongPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}