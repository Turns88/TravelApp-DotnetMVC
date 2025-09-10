using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelApp_DotnetMVC.Models;

namespace TravelApp_DotnetMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<ApplicationUser> ApplicationUser { get; set; } = null!;
    public DbSet<Destination> Destination { get; set; } = null!;
    public DbSet<Comment> Comment { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
}