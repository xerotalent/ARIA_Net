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
    public class IndexModel : PageModel
    {
        private readonly ARIA_Net.Data.ScoreContext _context;

        public IndexModel(ARIA_Net.Data.ScoreContext context)
        {
            _context = context;
        }

        public IList<Scoring_History> Scoring_History { get;set; }

        public async Task OnGetAsync()
        {
            Scoring_History = await _context.Scoring_History.ToListAsync();
        }
    }
}
