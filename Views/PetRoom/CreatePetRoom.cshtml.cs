using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.PetRoom
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
        ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return Page();
        }

        [BindProperty]
        public PetRoomModel PetRoomModel { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PetRoomModel.Add(PetRoomModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
