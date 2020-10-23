using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.Models;

namespace TravelLine.Repositories
{
    public interface ITravelLineRepo
    {
        bool SaveChanges();

        //COMMANDS
        IEnumerable<Post> GetAllPosts(int order = -1, int page = 0);
        IEnumerable<Post> GetAllUserPosts(int idUser, int order = -1, int page = 0);
        Post GetPostById(int id);
        void CreatePost(Post post);
        void DeletePost(Post post);
        void UpdatePost(Post post);

        //User
        User GetUserById(int userId);

        //Multimedia
        void CreateMultimedia(Multimedia mult);

        //Tag
        void CreateTag(Tag tag);
        Tag FindTagByName(string name);
        //void AttachTagsPosts(PostsTags tagToVinc);
    }
}
