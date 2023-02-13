using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.PetOwner
{
    public class CreateModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public CreateModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "OwnerId");
        ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
            return Page();
        }

        [BindProperty]
        public PetOwnerModel PetOwnerModel { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PetOwnerModel.Add(PetOwnerModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
