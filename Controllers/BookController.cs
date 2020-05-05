using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDotNewCoreApp.Models;
namespace MyDotNewCoreApp.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var context = new EntityFrameworkDbContext())
            {
                var model = await context.Authors.Include(a => a.Books).AsNoTracking().ToListAsync();
                return View(model);
            }
            
        }  
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using(var context = new EntityFrameworkDbContext())
            {
                var authors = await context.Authors.Select(a => new SelectListItem {
                    Value = a.AuthorId.ToString(), 
                    Text = $"{a.FirstName} {a.LastName}"
                }).ToListAsync();
                ViewBag.Authors = authors;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title, AuthorId")] Book book)
        {
            using (var context = new EntityFrameworkDbContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}