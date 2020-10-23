using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLine.Models.Enums
{
    [Flags]
    public enum PostsOrder
    {
        POST_DATE = 1,
        STORY_DATE = 2,
        LIKES = 3
    }
}
