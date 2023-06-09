﻿using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Entities;
using _153501_Bybko.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _153501_Bybko.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    public partial class EditSongPageViewModel : ObservableObject
    {
        private readonly ISongService _songService;
        public EditSongPageViewModel(ISongService songService)
        {
            _songService = songService;
        }

        [ObservableProperty]
        public Song song;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string album;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private string top;

        [RelayCommand]
        async void EditMember() => await EditSong();

        private async Task EditSong()
        {
            if (Name != null && Name != string.Empty)
                Song.Name = Name;
            if (Album != null && Album != string.Empty)
                Song.Album = Album;
            if (Top != null && Top != string.Empty)
                Song.Top = int.Parse(Top);

            await _songService.UpdateAsync(Song);

            // kostyl
            IDictionary<string, object> parameters =
                                  new Dictionary<string, object>()
            {
                { "Song", Song }
            };

            await Shell.Current.GoToAsync(nameof(SongDetailsPage), false, parameters);

            var navigationStack = Shell.Current.Navigation.NavigationStack.ToList();

            int startIndex = 1;
            int endIndex = navigationStack.Count - 2;
            for (int i = startIndex; i <= endIndex; i++)
            {
                var pageToRemove = navigationStack[i];
                Shell.Current.Navigation.RemovePage(pageToRemove);
            }
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
                string sourcePath = result.FullPath;
                string fileName = $"i{Song.Id}i.png";
                string destinationDirectory = "/storage/emulated/0/Android/data/com.companyname.x_153501_bybko.ui/cache/Images/";
                string destinationPath = Path.Combine(destinationDirectory, fileName);


                File.Move(sourcePath, destinationPath, true);
            }
        }
    }
}
