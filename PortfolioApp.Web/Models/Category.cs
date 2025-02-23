using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Web.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    // Navigation property
    public ICollection<BlogPost> BlogPosts { get; set; }
}