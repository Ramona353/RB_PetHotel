using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.Room
{
    public class DeleteModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DeleteModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RoomModel RoomModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.RoomModel == null)
            {
                return NotFound();
            }

            var roommodel = await _context.RoomModel.FirstOrDefaultAsync(m => m.RoomId == id);

            if (roommodel == null)
            {
                return NotFound();
            }
            else 
            {
                RoomModel = roommodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.RoomModel == null)
            {
                return NotFound();
            }
            var roommodel = await _context.RoomModel.FindAsync(id);

            if (roommodel != null)
            {
                RoomModel = roommodel;
                _context.RoomModel.Remove(RoomModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
