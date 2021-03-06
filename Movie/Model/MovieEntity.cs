using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Model
{
    public class MovieEntity
    {
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Director { get; set; }
    }
}
