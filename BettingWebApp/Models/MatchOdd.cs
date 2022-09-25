using System.ComponentModel.DataAnnotations;

namespace BettingWebApp.Models
{
    public class MatchOdd
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int MatchID { get; set; } //Entity Framework interprets a property as a foreign key property if it's named<navigation property name><primary key property name>
        //public virtual Match Match { get; set; }

        [StringLength(500, ErrorMessage = "The value declared for Specifier is too long")]
        [Required(ErrorMessage = "Specifier is required")]
        public string Specifier { get; set; }

        //[Range(0, 999.99)] //no idea which should be the range
        [Required(ErrorMessage = "Odd is required")]
        public double Odd { get; set; }

        public MatchOdd()
        {

        }
    }
}
