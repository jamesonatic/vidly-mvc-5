
using System;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genres Genre { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public int Stock { get; set; }
    }
}