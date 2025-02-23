using System.ComponentModel.DataAnnotations;
using PortfolioApp.Web.ValidationAttributes;

namespace PortfolioApp.Web.Models;

public class Comment
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, StringLength(1000)]
    [CommentTextValidator] //We will create this Custom Validator
    public string Text { get; set; }
    public DateTime PostedOn { get; set; }
    // Foreign Key
    public int BlogPostId { get; set; }
    // Navigation Property
    public BlogPost? BlogPost { get; set; }
}