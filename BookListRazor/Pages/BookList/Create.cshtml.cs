﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookListRazor.Model;
namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public Book Book { set; get; }
        public async Task OnGet()
        {
           // Book = await _db.Book.ToListAsync();
            
        }
        public async Task<IActionResult> OnPost(Book book)
        {
            if (ModelState.IsValid)
            {
                await _db.AddAsync(book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            return Page();
        }
    }
}