/*  
What did I add?
Attribute	        Purpose
[Required]	        Prevents missing required values
[StringLength]	    Limits text length
[EmailAddress]	    Checks email format
[Range(1, 8)]	    Restricts semester to 1–8
*/


using System.ComponentModel.DataAnnotations;

namespace CampusTrack.Api.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Student name is required")]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Department is required")]
    [StringLength(50)]
    public string Department { get; set; } = "";

    [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8")]
    public int Semester { get; set; }
}
