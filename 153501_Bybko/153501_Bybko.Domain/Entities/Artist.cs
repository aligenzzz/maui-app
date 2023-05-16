namespace _153501_Bybko.Domain.Entities
{
    public class Artist : Entity
    {
        public string? Genre { get; set; }
        public string? Country { get; set; }
        public List<Song>? Songs { get; set; }
    }
}
