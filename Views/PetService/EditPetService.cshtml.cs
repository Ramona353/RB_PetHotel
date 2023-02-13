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

namespace RB_PetHotel.Views.PetService
{
    public class EditModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public EditModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PetServiceModel PetServiceModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetServiceModel == null)
            {
                return NotFound();
            }

            var petservicemodel =  await _context.PetServiceModel.FirstOrDefaultAsync(m => m.PetId == id);
            if (petservicemodel == null)
            {
                return NotFound();
            }
            PetServiceModel = petservicemodel;
           ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
           ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
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

            _context.Attach(PetServiceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetServiceModelExists(PetServiceModel.PetId))
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

        private bool PetServiceModelExists(Guid? id)
        {
          return _context.PetServiceModel.Any(e => e.PetId == id);
        }
    }
}
