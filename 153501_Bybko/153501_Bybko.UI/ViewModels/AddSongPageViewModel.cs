using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;

namespace _153501_Bybko.UI.ViewModels
{
    [QueryProperty(nameof(Artist), "Artist")]
    public partial class AddSongPageViewModel : ObservableObject
    {
        private readonly ISongService _songService;
        public AddSongPageViewModel(ISongService songService)
        {
            _songService = songService;
        }

        [ObservableProperty]
        public Artist artist;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string album;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private string top;

        [RelayCommand]
        async void AddMember() => await AddSong();

        public async Task AddSong()
        {
            if (Name == null || Name == string.Empty ||
                Album == null || Album == string.Empty ||
                Top == null || Top == string.Empty)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Error...", "Invalid data!!!", "OK");
                return;
            }                

            Song song;
            try
            {
                song = new Song()
                {
                    Name = this.Name,
                    Album = this.Album,
                    Top = int.Parse(this.Top),
                    Artist = this.Artist,
                    ArtistId = this.Artist.Id
                };
            }
            catch
            {
                await Shell.Current.CurrentPage.DisplayAlert("Error...", "Invalid data!!!", "OK");
                return;
            }
            

            await _songService.AddAsync(song);

            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        void FileChoose() => ImageChoose();

        private async void ImageChoose()
        {

            FileResult result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                var songs = await _songService.GetAllAsync();
                int value = songs.Count + 1;

                string sourcePath = result.FullPath; 
                string fileName = $"i{value}i.png";
                string destinationDirectory = "/storage/emulated/0/Android/data/com.companyname.x_153501_bybko.ui/cache/Images/";
                string destinationPath = Path.Combine(destinationDirectory, fileName);


                File.Move(sourcePath, destinationPath, true);
            }
        }
    }
}
