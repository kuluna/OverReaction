using Microsoft.EntityFrameworkCore;
using OverReaction.Models;

namespace OverReaction
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<SlackEventLog> EventLogs { get; set; }
    }
}
