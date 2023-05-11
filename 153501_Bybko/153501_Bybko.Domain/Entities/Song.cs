namespace _153501_Bybko.Domain.Entities
{
    public class Song : Entity
    {
        public String? Album { get; set; }        
        public int Top { get; set; }  // the song's place in the chart
        public int Artist { get; set; }
    }
}
