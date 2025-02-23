using PortfolioApp.Web.Models;

namespace PortfolioApp.Web.ViewModels;

public class BlogPostDetailsViewModel
{
    public BlogPost BlogPost { get; set; }
    public Comment Comment { get; set; }
}