using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
	public class ProductViewComponent : ViewComponent
	{
		private readonly HamicContext _context;

		public ProductViewComponent(HamicContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = _context.TbProducts.Include(m => m.CategoryProduct)
				.Where(m => (bool)m.IsActive).Where(m => m.IsNew);
			return await Task.FromResult<IViewComponentResult>
				(View(items.OrderByDescending(m => m.ProductId).ToList()));
		}
	}
}
