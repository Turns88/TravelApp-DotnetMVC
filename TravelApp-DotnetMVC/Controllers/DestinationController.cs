using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TravelApp_DotnetMVC.Data;
using TravelApp_DotnetMVC.Models;
namespace TravelApp_DotnetMVC.Controllers;

public class DestinationController : Controller
{
    
    private readonly ILogger<DestinationController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;
    public DestinationController(IWebHostEnvironment env ,ILogger<DestinationController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        _env = env;
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
    public IActionResult Details(int id)
    {
        var destination = _context.Destination.Find(id);
        return View(destination);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Destination destination, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {

            if (imageFile != null && imageFile.Length > 0)
            {
                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                // Combine with wwwroot/images path
                var filePath = Path.Combine(_env.WebRootPath, "images", fileName);

                // Ensure the directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Store relative path in the database
                destination.Image = $"images/{fileName}";
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
