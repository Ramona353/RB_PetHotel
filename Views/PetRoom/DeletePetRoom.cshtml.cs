using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.PetRoom
{
    public class DeleteModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DeleteModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PetRoomModel PetRoomModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetRoomModel == null)
            {
                return NotFound();
            }

            var petroommodel = await _context.PetRoomModel.FirstOrDefaultAsync(m => m.PetId == id);

            if (petroommodel == null)
            {
                return NotFound();
            }
            else 
            {
                PetRoomModel = petroommodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.PetRoomModel == null)
            {
                return NotFound();
            }
            var petroommodel = await _context.PetRoomModel.FindAsync(id);

            if (petroommodel != null)
            {
                PetRoomModel = petroommodel;
                _context.PetRoomModel.Remove(PetRoomModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
