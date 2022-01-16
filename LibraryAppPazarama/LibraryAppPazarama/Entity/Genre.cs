using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAppPazarama.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Books> Books { get; set; }
    }
}
