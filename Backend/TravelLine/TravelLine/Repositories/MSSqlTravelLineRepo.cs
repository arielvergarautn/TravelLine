using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.DAOs;
using TravelLine.Models;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using TravelLine.Helpers;
using TravelLine.Models.Enums;
using TravelLine.CustomExceptions;

namespace TravelLine.Repositories
{
    public class MSSqlTravelLineRepo : ITravelLineRepo
    {
        private readonly TravelLineContext _context;
        private readonly MyConfigurations _configurations;

        public MSSqlTravelLineRepo(TravelLineContext context, MyConfigurations configurations)
        {
            _context = context;
            _configurations = configurations;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }


        //POSTS
        #region POST
        public void CreatePost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            _context.Posts.Add(post);
        }

        public void DeletePost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            _context.Posts.Remove(post);
        }

        public IEnumerable<Post> GetAllPosts(int order = -1, int page = 0)
        {
            IOrderedQueryable<Post> orderedQuery;
            var query = _context.Posts
                           .Include(x => x.User)
                           .Include(x => x.Likes)
                           .Include(x => x.Multimedias)
                           .Include(x => x.Tags);
            //Order by
            switch (order)
            {
                case (int)PostsOrder.POST_DATE:
                    orderedQuery = query.OrderBy(x => x.PostDate);
                    break;
                case (int)PostsOrder.STORY_DATE:
                    orderedQuery = query.OrderBy(x => x.StoryDate);
                    break;
                case (int)PostsOrder.LIKES:
                    orderedQuery = query.OrderByDescending(p => p.Likes.Count(l => l.PostId == p.Id));
                    break;
                default:
                    orderedQuery = query.OrderBy(x => x.Id);
                    break;
            }

            var a = _configurations.PostsPerPage;
            return orderedQuery.Skip(a * page).Take(a).ToList();
                           
        }

        public IEnumerable<Post> GetAllUserPosts(int idUser, int order = -1, int page = 0)
        {
            IOrderedQueryable<Post> orderedQuery;
            var query = _context.Posts
                           .Where(x => x.User.Id == idUser)
                           .Include(x => x.User)
                           .Include(x => x.Likes)
                           .Include(x => x.Multimedias)
                           .Include(x => x.Tags);
            //Order by
            switch (order)
            {
                case (int) PostsOrder.POST_DATE:
                    orderedQuery = query.OrderBy(x => x.PostDate);
                    break;
                case (int) PostsOrder.STORY_DATE:
                    orderedQuery = query.OrderBy(x => x.StoryDate);
                    break;
                case (int) PostsOrder.LIKES:
                    orderedQuery = query.OrderByDescending(p => p.Likes.Count(l => l.PostId == p.Id));
                    break;
                default:
                    orderedQuery = query.OrderBy(x => x.Id);
                    break;
            }

            var a = _configurations.PostsPerPage;
            return orderedQuery.Skip(a * page).Take(a).ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts
                           .Where(x => x.Id == id)
                           .Include(x => x.User)
                           .Include(x => x.Likes)
                           .Include(x => x.Multimedias)
                           .Include(x => x.Tags)
                           .FirstOrDefault();
        }

        public void UpdatePost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            _context.Posts.Update(post);
        }
        #endregion

        //USER
        #region USER
        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }


        #endregion

        #region MULTIMEDIA
        public void CreateMultimedia(Multimedia mult)
        {
            if (mult == null)
            {
                throw new ArgumentNullException(nameof(mult));
            }
            _context.Multimedias.Add(mult);
        }

        public void CreateTag(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            if(_context.Tags.Any(x => x.Name == tag.Name))
            {
                throw new ElementAlreadyExistsException(tag.Name);
            }
            _context.Tags.Add(tag);
            
        }

        public Tag FindTagByName(string name)
        {
            if (name == null || String.IsNullOrEmpty(name)) {
                throw new ArgumentNullException(nameof(name));
            }
            return _context.Tags.FirstOrDefault(x => x.Name == name);
        }

        //public void AttachTagsPosts(PostsTags tagToVinc)
        //{
        //    if (tagToVinc == null)
        //    {
        //        throw new ArgumentNullException(nameof(tagToVinc));
        //    }
        //    _context.Attach(tagToVinc);
        //}


        #endregion
    }
}
