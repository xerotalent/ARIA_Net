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
        public Scoring_History Scoring_History { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scoring_History = await _context.Scoring_History.FirstOrDefaultAsync(m => m.ID == id);

            if (Scoring_History == null)
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

            Scoring_History = await _context.Scoring_History.FindAsync(id);

            if (Scoring_History != null)
            {
                _context.Scoring_History.Remove(Scoring_History);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
