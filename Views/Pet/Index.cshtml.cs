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
    public class IndexModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public IndexModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PetModel> PetModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PetModel != null)
            {
                PetModel = await _context.PetModel.ToListAsync();
            }
        }
    }
}
