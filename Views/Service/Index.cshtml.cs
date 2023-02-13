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
    public class IndexModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public IndexModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ServiceModel> ServiceModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ServiceModel != null)
            {
                ServiceModel = await _context.ServiceModel.ToListAsync();
            }
        }
    }
}
