using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.Pet
{
    public class DetailsModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DetailsModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public PetModel PetModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetModel == null)
            {
                return NotFound();
            }

            var petmodel = await _context.PetModel.FirstOrDefaultAsync(m => m.PetId == id);
            if (petmodel == null)
            {
                return NotFound();
            }
            else 
            {
                PetModel = petmodel;
            }
            return Page();
        }
    }
}
