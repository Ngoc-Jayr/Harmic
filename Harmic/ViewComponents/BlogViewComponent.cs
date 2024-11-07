using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly HamicContext _context;

        public BlogViewComponent(HamicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs
                .Where(b => (bool)b.IsActive == true)
                .OrderByDescending(b => b.BlogId);

            return await Task.FromResult<IViewComponentResult>
                (View(items.ToList())
            );
        }
    }
}
