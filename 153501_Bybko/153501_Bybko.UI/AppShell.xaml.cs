using _153501_Bybko.UI.Pages;

namespace _153501_Bybko.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(SongDetailsPage), 
                              typeof(SongDetailsPage));
        Routing.RegisterRoute(nameof(EditSongPage),
                              typeof(EditSongPage));
    }
}
