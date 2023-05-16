using _153501_Bybko.Application.Abstractions;
using _153501_Bybko.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153501_Bybko.UI.ViewModels
{
    public partial class AddArtistPageViewModel : ObservableObject
    {
        private readonly IArtistService _artistService;
        public AddArtistPageViewModel(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string genre;

        [ObservableProperty]
        private string country;

        [RelayCommand]
        async void AddGroup() => await AddArtist();

        public async Task AddArtist()
        {
            if (Name == null || Name == string.Empty ||
                Genre == null || Genre == string.Empty ||
                Country == null || Country == string.Empty)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Error...", "Invalid data!!!", "OK");
                return;
            }

            Artist artist = new Artist()
            {
                Name = this.Name,
                Genre = this.Genre,
                Country = this.Country
            };

            await _artistService.AddAsync(artist);

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
