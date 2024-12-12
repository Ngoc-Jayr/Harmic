using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Harmic.Models;

namespace Harmic.Controllers
{
    public class ContactController : Controller
    {
        private readonly HamicContext _context;
        public ContactController(HamicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string phone, string email, string massage)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = massage;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
