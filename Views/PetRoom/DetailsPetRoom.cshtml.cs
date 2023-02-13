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
    public class DetailsModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DetailsModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
