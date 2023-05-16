using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Entities;
using _153501_Bybko.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _153501_Bybko.UI.ViewModels
{
    public partial class ArtistsPageViewModel : ObservableObject
    {
        private readonly IArtistService _artistService;
        private readonly ISongService _songService;

        public ArtistsPageViewModel(IArtistService artistService, ISongService songService)
        {
            _artistService = artistService;
            _songService = songService;
        }

        public ObservableCollection<Artist> Artists { get; set; } = new();

        public ObservableCollection<Song> Songs { get; set; } = new();

        [ObservableProperty]
        Artist selectedArtist;

        [RelayCommand]
        void UpdateAll()
        {
            Artist temp = SelectedArtist;
            UpdateGroupList();
            SelectedArtist = temp;

            UpdateMembersList();
        }

        [RelayCommand]
        async void UpdateGroupList() => await GetArtists();

        [RelayCommand]
        async void UpdateMembersList() => await GetSongs();

        public async Task GetArtists()
        {
            var artists = await _artistService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Artists.Clear();
                foreach (var artist in artists)
                    Artists.Add(artist);
            });
        }

        public async Task GetSongs()
        {
            if (SelectedArtist == null) return;

            var songs = await _songService.GetArtistSongs(SelectedArtist.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach (var song in songs)
                    Songs.Add(song);
            });
        }


        [RelayCommand]
        async void ShowDetails(Song song) => await GotoDetailsPage(song);

        private async Task GotoDetailsPage(Song song)
        {
            IDictionary<string, object> parameters =
                                  new Dictionary<string, object>()
            {
                { "Song", song }
            };

            await Shell.Current.GoToAsync(nameof(SongDetailsPage), parameters);
        }

        [RelayCommand]
        async void AddMemberOrGroup() => await AddSongOrArtist();

        private async Task AddSongOrArtist()
        {
            string action = await Shell.Current.CurrentPage.DisplayActionSheet("Add new...", "Cancel", null, "Artist", "Song");

            if (action == null || SelectedArtist == null) return;

            if (action == "Artist")
                await Shell.Current.GoToAsync(nameof(AddArtistPage));
            if (action == "Song")
            {
                IDictionary<string, object> parameters =
                                 new Dictionary<string, object>()
                {
                    { "Artist", SelectedArtist }
                };

                await Shell.Current.GoToAsync(nameof(AddSongPage), parameters);
            }
        }
    }
}
