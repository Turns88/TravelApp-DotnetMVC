namespace TravelApp_DotnetMVC.Models;

public class Destination
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Image { get; private set; } = null!;
    public string Currency { get; private set; } = null!;
    public ICollection<Comment>? Comments { get; private set; }
}