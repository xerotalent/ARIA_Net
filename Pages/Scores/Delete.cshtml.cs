using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ARIA_Net.Data;
using ARIA_Net.Models;

namespace ARIA_Net.Pages.Scores
{
    public class DeleteModel : PageModel
    {
        private readonly ARIA_Net.Data.ScoreContext _context;

        public DeleteModel(ARIA_Net.Data.ScoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Application_Score Application_Score { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application_Score = await _context.Application_Score.FirstOrDefaultAsync(m => m.ID == id);

            if (Application_Score == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application_Score = await _context.Application_Score.FindAsync(id);

            if (Application_Score != null)
            {
                _context.Application_Score.Remove(Application_Score);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
