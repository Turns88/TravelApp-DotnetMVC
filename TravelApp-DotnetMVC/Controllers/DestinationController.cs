using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelApp_DotnetMVC.Data;
using TravelApp_DotnetMVC.Models;
namespace TravelApp_DotnetMVC.Controllers;

public class DestinationController : Controller
{
    
    private readonly ILogger<DestinationController> _logger;
    private readonly ApplicationDbContext _context;
    public DestinationController(ILogger<DestinationController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var destinations = _context.Destination;
        IQueryable<Destination> destinationsQuery = 
            from destination in destinations
            select destination;
        var destinationList = destinationsQuery.ToList();
        return View(destinationList);
    }
    [Route("destination/{destinationId}/comment")]
    public IActionResult Comment(int id)
    {
        var comments = _context.Comment;
        // Define the query expression.
        IQueryable<Comment> commentQuery =
            from comment in comments
            where comment.DestinationId == id
            select comment;
        
        return View(commentQuery);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Destination destination, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            
            
            if (destination.Image != null && destination.Image.Length > 0)
            {
                MemoryStream ms = new MemoryStream();
                image.CopyTo(ms);
                destination.Image = ms.ToArray();
            }
            Destination newDestination = new Destination
            {
                Name = destination.Name,
                Description = destination.Description,
                Currency = destination.Currency,
                Image = destination.Image
            };


            _context.Destination.Add(newDestination);
            _context.SaveChanges();
            
            
            return RedirectToAction(nameof(Index));
        }
        Console.WriteLine("ModelState not valid");

        return View();

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}