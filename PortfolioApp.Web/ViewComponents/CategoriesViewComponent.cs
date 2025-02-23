using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Data;
using PortfolioApp.Web.Models;

namespace PortfolioApp.Web.ViewComponents;

public class CategoriesViewComponent: ViewComponent
{
    private readonly PortfolioDBContext _context;
    public CategoriesViewComponent(PortfolioDBContext context)
    {
        _context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Category> categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
        //View Location shuld be : Views/Shared/Components/Categories/Default.cshtml
        return View(categories); 
    }
}