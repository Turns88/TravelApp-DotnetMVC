namespace TravelApp_DotnetMVC.Models;

public class Destination
{
    public int Id { get; private set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte[]? Image { get; set; }
    public string Currency { get;  set; } = null!;
    public ICollection<Comment>? Comments { get;  set; }
}