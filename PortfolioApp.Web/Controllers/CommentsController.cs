using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Data;
using PortfolioApp.Web.Models;
using PortfolioApp.Web.ViewModels;

namespace PortfolioApp.Web.Controllers;

public class CommentsController: Controller
{
    private readonly PortfolioDBContext _context;
    public CommentsController(PortfolioDBContext context)
    {
        _context = context;
    }
    // POST: Comments/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int blogPostId, Comment comment)
    {
        if (ModelState.IsValid)
        {
            comment.BlogPostId = blogPostId;
            comment.PostedOn = DateTime.UtcNow;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "BlogPosts", new { slug = _context.BlogPosts?.Find(blogPostId)?.Slug });
        }
        // If validation fails, reload the blog post details with errors
        var blogPost = await _context.BlogPosts
            .Include(b => b.Author)
            .Include(b => b.Comments)
            .FirstOrDefaultAsync(b => b.Id == blogPostId);
        if (blogPost == null)
        {
            ViewBag.ErrorMessage = "Blog Post Not Found";
            return View("Error");
        }
        var viewModel = new BlogPostDetailsViewModel
        {
            BlogPost = blogPost,
            Comment = comment
        };
        return View("../BlogPosts/Details", viewModel);
    }
}