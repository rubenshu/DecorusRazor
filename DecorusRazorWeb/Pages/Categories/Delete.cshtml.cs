using DecorusRazorWeb.Model;
using DecorusWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecorusRazorWeb.Pages.Categories
{
    [BindProperties]
    public class  DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            _db.Categories.Remove(Category);
            if (Category != null)
            {
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
