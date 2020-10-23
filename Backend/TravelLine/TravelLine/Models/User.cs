using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLine.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string NickName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public State State { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<Friends> Friends { get; set; }
        public IList<Likes> Likes { get; set; }
    }
}
