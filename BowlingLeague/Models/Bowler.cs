using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        
        public int BowlerID { get; set; }
        [Required]
        public string BowlerFirstName { get; set; }

        [MaxLength(1, ErrorMessage = "Initial cannot be longer than 1 character")]
        public string BowlerMiddleInit { get; set; }
        [Required]
        public string BowlerLastName { get; set; }
        [Required]
        public string BowlerAddress { get; set; }
        [Required]
        public string BowlerCity { get; set; }
        [Required]
        [MaxLength(2, ErrorMessage = "State cannot be longer than 2 characters")]
        public string BowlerState { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "State cannot be longer than 5 characters")]
        public string BowlerZip { get; set; }
        [MaxLength(13, ErrorMessage = "Phone number cannot be longer than 13 characters")]
        public string BowlerPhoneNumber { get; set; }
        [Required]
        public int TeamID { get; set; }

        public Team Team { get; set; }
    }
}
