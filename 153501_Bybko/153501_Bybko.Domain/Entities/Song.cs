﻿namespace _153501_Bybko.Domain.Entities
{
    public class Song : Entity
    {
        public String? Image { get; set; }
        public String? Album { get; set; }        
        public int Top { get; set; }  // the song's place in the chart
        public Artist? Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
