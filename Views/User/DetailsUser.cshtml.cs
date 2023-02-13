using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Views.User
{
    public class DetailsModel : PageModel
    {
        private readonly RB_PetHotel.Data.ApplicationDbContext _context;

        public DetailsModel(RB_PetHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public UserModel UserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.UserModel == null)
            {
                return NotFound();
            }

            var usermodel = await _context.UserModel.FirstOrDefaultAsync(m => m.UserId == id);
            if (usermodel == null)
            {
                return NotFound();
            }
            else 
            {
                UserModel = usermodel;
            }
            return Page();
        }
    }
}
