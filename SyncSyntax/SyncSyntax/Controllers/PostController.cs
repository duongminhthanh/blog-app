using Microsoft.AspNetCore.Mvc;
using SyncSyntax.Data;

namespace SyncSyntax.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var postViewModel = new Models.ViewModels.PostViewModel();
            postViewModel.Categories = _context.Categories
                .Select(c =>
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(postViewModel);
        }
    }
}
