using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARIA_Net.Data;
using ARIA_Net.Models;

namespace ARIA_Net.Pages.Scores
{
    public class EditModel : PageModel
    {
        private readonly ARIA_Net.Data.ScoreContext _context;

        public EditModel(ARIA_Net.Data.ScoreContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Scoring_History).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Scoring_HistoryExists(Scoring_History.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Scoring_HistoryExists(int id)
        {
            return _context.Scoring_History.Any(e => e.ID == id);
        }
    }
}
