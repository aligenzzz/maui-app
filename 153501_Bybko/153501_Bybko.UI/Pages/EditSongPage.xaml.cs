using _153501_Bybko.UI.ViewModels;

namespace _153501_Bybko.UI.Pages;

public partial class EditSongPage : ContentPage
{
	public EditSongPage(EditSongPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}