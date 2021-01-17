
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genres Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime DateRelease { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int Stock { get; set; }
    }
}