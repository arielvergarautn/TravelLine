using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLine.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        //public State State { get; set; }
        //public IEnumerable<PostReadDto> Posts { get; set; }
        //public IEnumerable<Friends> Friends { get; set; }
        //public IEnumerable<Likes> Likes { get; set; }
    }
}
