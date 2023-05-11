using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Entities;
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
            var songs = await _songService.GetArtistSongs(SelectedArtist.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach (var song in songs)
                    Songs.Add(song);
            });
        }
    }
}
