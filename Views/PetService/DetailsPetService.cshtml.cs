using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.PetService
{
    public class DetailsModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DetailsModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public PetServiceModel PetServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PetServiceModel == null)
            {
                return NotFound();
            }

            var petservicemodel = await _context.PetServiceModel.FirstOrDefaultAsync(m => m.PetId == id);
            if (petservicemodel == null)
            {
                return NotFound();
            }
            else 
            {
                PetServiceModel = petservicemodel;
            }
            return Page();
        }
    }
}
