using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeeamFootballProject.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Surname { get; set; }

        [Required]
        public Genders Gender { get; set; }

        [Required]
        public string DateBirth { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        [ValidateNever]
        public TeamNames NameTeam { get; set; }

        [Required]
        public Countries Country { get; set; }
    }
}
