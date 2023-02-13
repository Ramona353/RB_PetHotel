using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.PetOwner
{
    public class EditModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public EditModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PetOwnerModel PetOwnerModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetOwnerModel == null)
            {
                return NotFound();
            }

            var petownermodel =  await _context.PetOwnerModel.FirstOrDefaultAsync(m => m.OwnerId == id);
            if (petownermodel == null)
            {
                return NotFound();
            }
            PetOwnerModel = petownermodel;
           ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "OwnerId");
           ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PetOwnerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerModelExists(PetOwnerModel.OwnerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PetOwnerModelExists(Guid? id)
        {
          return _context.PetOwnerModel.Any(e => e.OwnerId == id);
        }
    }
}
