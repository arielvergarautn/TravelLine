using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLine.DTOs
{
    public class PostCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public DateTime StoryDate { get; set; }
        [MaxLength(500)]
        public string Recommendations { get; set; }
        public int UserId { get; set; }
        public IList<MultimediaCreateDto> Multimedias { get; set; }
        public IList<TagCreateDto> Tags { get; set; }
    }
}
