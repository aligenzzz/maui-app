namespace _153501_Bybko.Domain.Entities
{
    public class Artist : Entity
    {
        public String? Genre { get; set; }
        public String? Country { get; set; }
        public List<Song>? Songs { get; set; }
    }
}
