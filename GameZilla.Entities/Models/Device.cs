namespace GameZilla.Entities.Models
{
    public class Device : BaseEntity
    {
        public string Icon { get; set; } = string.Empty;
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();

    }
}
