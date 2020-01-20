using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ARIA_Net.Data;
using ARIA_Net.Models;

namespace ARIA_Net.Pages.Scores
{
    public class CreateModel : PageModel
    {
        private readonly ARIA_Net.Data.ScoreContext _context;

        public CreateModel(ARIA_Net.Data.ScoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scoring_History Scoring_History { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scoring_History.Add(Scoring_History);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
