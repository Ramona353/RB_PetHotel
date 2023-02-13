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

namespace RB_PetHotel.Views.PetRoom
{
    public class EditModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public EditModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PetRoomModel PetRoomModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetRoomModel == null)
            {
                return NotFound();
            }

            var petroommodel =  await _context.PetRoomModel.FirstOrDefaultAsync(m => m.PetId == id);
            if (petroommodel == null)
            {
                return NotFound();
            }
            PetRoomModel = petroommodel;
           ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
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

            _context.Attach(PetRoomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetRoomModelExists(PetRoomModel.PetId))
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

        private bool PetRoomModelExists(Guid? id)
        {
          return _context.PetRoomModel.Any(e => e.PetId == id);
        }
    }
}
