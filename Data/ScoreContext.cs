using Microsoft.EntityFrameworkCore;

namespace ARIA_Net.Data
{
    public class ScoreContext : DbContext
    {
        public ScoreContext (
            DbContextOptions<ScoreContext> options)
            : base(options)
        {
        }

        public DbSet<ARIA_Net.Models.Scoring_History> Scoring_History {get; set;}
    }
}