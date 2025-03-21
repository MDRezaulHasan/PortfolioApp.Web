using PortfolioApp.Web.Models;

namespace PortfolioApp.Web.ViewModels;

public class CategoryPostsViewModel
{
    public List<BlogPost>? Posts { get; set; }
    public int? CurrentPage { get; set; }
    public int? TotalPages { get; set; }
    public string? CategoryName { get; set; }
    public int? CategoryId { get; set; }
}