using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Entities;
using _153501_Bybko.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153501_Bybko.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    public partial class SongDetailsPageViewModel : ObservableObject
    {
        private readonly IArtistService _artistService;
        private readonly ISongService _songService;
        public SongDetailsPageViewModel(IArtistService artistService, ISongService songService) 
        { 
            _artistService = artistService;
            _songService = songService;
        }

        [ObservableProperty]
        static public Song song;

        [RelayCommand]
        async void EditMember(Song song) => await GotoEditMemberPage(song);

        private async Task GotoEditMemberPage(Song song)
        {
            IDictionary<string, object> parameters =
                                  new Dictionary<string, object>()
            {
                { "Song", song }
            };

            await Shell.Current.GoToAsync(nameof(EditSongPage), parameters);
        }

        [RelayCommand]
        async void MoveMember() => await MoveSong();

        private async Task MoveSong()
        {
            var artists = await _artistService.GetAllAsync();
            string[] names = artists.Select(artist => artist.Name).ToArray();

            string action = await Shell.Current.CurrentPage.DisplayActionSheet("Move to...", "Cancel", null, names);

            if (action == null || action == song.Artist.Name) return;

            foreach (Artist artist in artists)
            {
                if (artist.Name == action)
                {
                    song.Artist = artist;
                    song.ArtistId = artist.Id;

                    break;
                }
            }

            await _songService.UpdateAsync(song);
        }
    }
}
