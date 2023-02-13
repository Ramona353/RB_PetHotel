using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.PetOwner
{
    public class DeleteModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DeleteModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PetOwnerModel PetOwnerModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetOwnerModel == null)
            {
                return NotFound();
            }

            var petownermodel = await _context.PetOwnerModel.FirstOrDefaultAsync(m => m.OwnerId == id);

            if (petownermodel == null)
            {
                return NotFound();
            }
            else 
            {
                PetOwnerModel = petownermodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.PetOwnerModel == null)
            {
                return NotFound();
            }
            var petownermodel = await _context.PetOwnerModel.FindAsync(id);

            if (petownermodel != null)
            {
                PetOwnerModel = petownermodel;
                _context.PetOwnerModel.Remove(PetOwnerModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
