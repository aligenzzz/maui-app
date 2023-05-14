using _153501_Bybko.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Bybko.UI.ViewModels
{
    [QueryProperty(nameof(Song), "Song")]
    partial class SongDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public Song song;
    }
}
