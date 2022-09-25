using BettingWebApp.Models;
using System.Collections.Generic;

namespace BettingWebApp.ViewModels
{
    public class MatchOddViewModel
    {
        public Match Match { get; set; }
        public IEnumerable<MatchOdd> MatchOdds { get; set; }
        public MatchOdd MatchOdd { get; set; }

    }
}
