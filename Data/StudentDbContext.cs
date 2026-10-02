
using CampusTrack.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusTrack.Api.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
}
