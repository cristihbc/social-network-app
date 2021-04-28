using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using System.Collections.Generic;
using Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private static IPost _postService = new PostService();
        private static IComment _commentService = new CommentService();
        private static IUser _userService = new UserService();

        [HttpGet]
        public IActionResult GetPosts()
        {
            List<PostEntity> posts = _postService.GetPosts();

            return ()
        }
    }