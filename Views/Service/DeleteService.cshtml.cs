using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.Service
{
    public class DeleteModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DeleteModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ServiceModel ServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ServiceModel == null)
            {
                return NotFound();
            }

            var servicemodel = await _context.ServiceModel.FirstOrDefaultAsync(m => m.ServiceId == id);

            if (servicemodel == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceModel = servicemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ServiceModel == null)
            {
                return NotFound();
            }
            var servicemodel = await _context.ServiceModel.FindAsync(id);

            if (servicemodel != null)
            {
                ServiceModel = servicemodel;
                _context.ServiceModel.Remove(ServiceModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
