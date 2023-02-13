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
    public class IndexModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public IndexModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PetRoomModel> PetRoomModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PetRoomModel != null)
            {
                PetRoomModel = await _context.PetRoomModel
                .Include(p => p.Room).ToListAsync();
            }
        }
    }
}
