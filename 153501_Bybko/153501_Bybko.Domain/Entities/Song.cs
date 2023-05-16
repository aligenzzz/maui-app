namespace _153501_Bybko.Domain.Entities
{
    public class Song : Entity
    {
        public string? Image { get; set; } 
        public string? Album { get; set; }        
        public int Top { get; set; }  // the song's place in the chart
        public Artist? Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
