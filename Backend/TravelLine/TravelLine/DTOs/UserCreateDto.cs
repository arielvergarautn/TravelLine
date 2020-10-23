using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.Models;

namespace TravelLine.DTOs
{
    public class UserCreateDto
    {
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
        //public State State { get; set; } //Todo: hacer que el tenga el estado publico por defecto.
        //public IEnumerable<PostCreateDto> Posts { get; set; } 
        //public IEnumerable<Friends> Friends { get; set; }
        //public IEnumerable<Likes> Likes { get; set; }
    }
}
