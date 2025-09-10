namespace TravelApp_DotnetMVC.Models;

public class Comment
{
    public string Id { get; private set; } = null!;
    public string Text { get; private set; } = null!;
    public DateTime Created { get; private set; }
    public string ApplicationUserId { get; private  set; } = null!;
    public int DestinationId { get; private set; } 
}