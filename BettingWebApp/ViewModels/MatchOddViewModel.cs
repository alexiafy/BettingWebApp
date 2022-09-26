using BettingWebApp.Models;
using System.Collections.Generic;

namespace BettingWebApp.ViewModels
{
    //This class eventually was not used, but it might be used
    //for updates in the near future, thus, I will not delete it
    public class MatchOddViewModel
    {
        public Match Match { get; set; }
        public IEnumerable<MatchOdd> MatchOdds { get; set; }
        public MatchOdd MatchOdd { get; set; }

    }
}
