using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazor.Model;
namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Book Book { set; get; }
        public async Task OnGet(int id)
        {
            Book = await  _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost(Book book)
        {
            if (ModelState.IsValid)
            {
                var dbBook=await _db.Book.FindAsync(book.Id);
                dbBook.Author = book.Author;
                dbBook.ISBN = book.ISBN;
                dbBook.Name = book.Name;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}