using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BettingWebApp.Models;

namespace BettingWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BettingWebApp.Models.Match> Match { get; set; }
        public DbSet<BettingWebApp.Models.MatchOdd> MatchOdd { get; set; }
    }
}
