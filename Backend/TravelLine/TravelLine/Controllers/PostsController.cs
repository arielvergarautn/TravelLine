using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelLine.DAOs;
using TravelLine.DTOs;
using TravelLine.Models;
using TravelLine.Models.Enums;
using TravelLine.Profiles;
using TravelLine.Repositories;


namespace TravelLine.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ITravelLineRepo _repository;
        private readonly IMapper _mapper;

        public PostsController(ITravelLineRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Posts/all/1/0
        [HttpGet("All/{order?}/{page?}")]
        public ActionResult<IEnumerable<PostReadDto>> GetPosts(int order = (int)PostsOrder.POST_DATE, int page = 0)
        {
            try 
            {
                var posts = _repository.GetAllPosts(order, page);
                var postsMapped = _mapper.Map<IList<PostReadDto>>(posts);
                return Ok(postsMapped);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/Posts/ByUser/1/1/0
        [HttpGet("ByUser/{id}/{order?}/{page?}")]
        public ActionResult<IEnumerable<PostReadDto>> GetPostsFiltered(int id, int order = (int)PostsOrder.POST_DATE, int page = 0)
        {
            try
            {
                var posts = _repository.GetAllUserPosts(id, order, page);
                var postsMapped = _mapper.Map<IList<PostReadDto>>(posts);
                return Ok(postsMapped);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: api/Posts/ById/5
        [HttpGet("ById/{id}", Name = "GetPostById")]
        public ActionResult<Post> GetPost(int id)
        {
            try
            {
                var post = _repository.GetPostById(id);
                
                if (post == null)
                {
                    return NotFound();
                }

                var postMapped = _mapper.Map<PostReadDto>(post);

                return Ok(postMapped);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // Delete: api/Posts/5
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id) {
            try
            {
                var post = _repository.GetPostById(id);
                
                //Validation
                if (post == null)
                {
                    return NotFound();
                }

                //Delete
                _repository.DeletePost(post);
                _repository.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //POST api/Posts
        [HttpPost]
        public ActionResult<PostReadDto> CreatePost(PostCreateDto post)
        {
            try
            {

                //Maper
                var postModel = _mapper.Map<Post>(post);

                //Get user
                User user = _repository.GetUserById(post.UserId);

                //Validations
                if (user == null) {
                    return NotFound();
                }
                postModel.User = user;

                ////Create Multimedias
                //var multimediasModel = _mapper.Map<IList<Multimedia>>(post.Multimedias);
                //postModel.Multimedias = multimediasModel;

                //CREATE POST
                _repository.CreatePost(postModel);

                //Save the changes and everything should be working!
                _repository.SaveChanges();

                //Read
                var postReadDto = _mapper.Map<PostReadDto>(postModel);

                return CreatedAtAction(nameof(GetPost), new { id = postReadDto.Id }, postReadDto);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        ////POST api/Posts
        //[HttpPut]
        //public ActionResult<Post> UpdatePost(int id, Post post)
        //{
        //    try
        //    {

        //        ////Maper
        //        //var commandModel = _mapper.Map<Command>(post);

        //        //Create
        //        _repository.UpdatePost(post);
        //        _repository.SaveChanges();

        //        ////Read
        //        //var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
        //        //return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        //        // return Created(commandReadDto, );

        //        return Ok(post);
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
