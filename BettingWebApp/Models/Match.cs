using System.ComponentModel.DataAnnotations;
using System;

namespace BettingWebApp.Models
{
    public class Match
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [StringLength(500, ErrorMessage = "The value declared for description is too long")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Match date is required")]
        public DateTime MatchDate { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Match time is required")]
        public DateTime MatchTime { get; set; }

        [StringLength(100, ErrorMessage = "The value declared for TeamA is too long")]
        [Required(ErrorMessage = "TeamA is required")]
        public string TeamA { get; set; }

        [StringLength(100, ErrorMessage = "The value declared for TeamB is too long")]
        [Required(ErrorMessage = "TeamB is required")]
        public string TeamB { get; set; }

        [EnumDataType(typeof(SportEnum))]
        [Required(ErrorMessage = "Sport is required")]
        public SportEnum Sport { get; set; }

        //public virtual ICollection<MatchOdd> MatchOdds { get; set; }

        public enum SportEnum
        {
            Football,
            Basketball
        }

        public Match()
        {

        }
    }
}
