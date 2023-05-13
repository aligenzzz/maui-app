namespace _153501_Bybko.Domain.Entities
{
    public class Artist : Entity
    {
        public Artist() 
        {
            Id = -1;
            Name = "";
            Image = "";
            Genre = "";
            Country = "";

            Songs = new();
        }
        public Artist(int id, string name, string image, string genre, string country) 
        {
            Id = id;
            Name = name;
            Image = image;
            Genre = genre;
            Country = country;

            Songs = new();        
        }

        public string Genre { get; set; }
        public string Country { get; set; }
        public List<Song> Songs { get; set; }
    }
}
