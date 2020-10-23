using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLine.Models
{
    public class Multimedia
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Url { get; set; }
        public Post Post { get; set; }
    }
}
