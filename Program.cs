
using CampusTrack.Api.Data;
using CampusTrack.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite database
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlite("Data Source=campustrack.db"));

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseDefaultFiles(); //This allows ASP.NET Core to serve your HTML dashboard from the wwwroot folder.
app.UseStaticFiles();  //Keep your existing Swagger configuration and API endpoints unchanged.

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<StudentDbContext>();

    db.Database.EnsureCreated();
}

// GET: Retrieve all students
app.MapGet("/api/students", async (StudentDbContext db) =>
{
    return Results.Ok(await db.Students.ToListAsync());
});

// GET: Retrieve student by ID
app.MapGet("/api/students/{id}", async (int id, StudentDbContext db) =>
{
    var student = await db.Students.FindAsync(id);

    if (student is null)
        return Results.NotFound();

    return Results.Ok(student);
});

// POST: Add a new student

app.MapPost("/api/students", async (Student student, StudentDbContext db) =>
{
    var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

    var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(
        student,
        new System.ComponentModel.DataAnnotations.ValidationContext(student),
        validationResults,
        validateAllProperties: true
    );

    if (!isValid)
    {
        return Results.BadRequest(new
        {
            errors = validationResults.Select(e => e.ErrorMessage)
        });
    }

    student.Id = 0;

    db.Students.Add(student);

    await db.SaveChangesAsync();

    return Results.Created(
        $"/api/students/{student.Id}",
        student
    );
});


// PUT: Update student

app.MapPut("/api/students/{id}", async (int id, Student updated, StudentDbContext db) =>
{
    var student = await db.Students.FindAsync(id);

    if (student is null)
        return Results.NotFound();

    var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

    var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(
        updated,
        new System.ComponentModel.DataAnnotations.ValidationContext(updated),
        validationResults,
        validateAllProperties: true
    );

    if (!isValid)
    {
        return Results.BadRequest(new
        {
            errors = validationResults.Select(e => e.ErrorMessage)
        });
    }

    student.FullName = updated.FullName;
    student.Email = updated.Email;
    student.Department = updated.Department;
    student.Semester = updated.Semester;

    await db.SaveChangesAsync();

    return Results.Ok(student);
});


// DELETE: Remove student
app.MapDelete("/api/students/{id}", async (int id, StudentDbContext db) =>
{
    var student = await db.Students.FindAsync(id);

    if (student is null)
        return Results.NotFound();

    db.Students.Remove(student);

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
