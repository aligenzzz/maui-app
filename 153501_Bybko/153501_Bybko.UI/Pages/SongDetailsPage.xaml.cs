using _153501_Bybko.UI.ViewModels;

namespace _153501_Bybko.UI.Pages;

public partial class SongDetailsPage : ContentPage
{
	public SongDetailsPage()
	{
		InitializeComponent();

		BindingContext = new SongDetailsPageViewModel();
	}
}