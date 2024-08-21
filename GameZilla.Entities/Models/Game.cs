namespace GameZilla.Entities.Models
{
    public class Game : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;

        public Category Category { get; set; } = default!; // Nav prop
        public int CategoryId { get; set; } // FK

        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();

    }
}
