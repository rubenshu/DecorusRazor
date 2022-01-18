using DecorusRazorWeb.Model;
using DecorusWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DecorusRazorWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Display Order can not be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated succesfully";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
