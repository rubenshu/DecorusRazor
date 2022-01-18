using DecorusRazorWeb.Model;
using DecorusWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecorusRazorWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
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
            var obj = _db.Categories.Find(Category.Id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted succesfully";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
