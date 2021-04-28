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

            return (posts.Count != 0) ? Ok(posts) : NoContent();
        }

        [HttpGet()]
        public IActionResult GetPost(uint id)
        {
            PostEntity post = _postService.GetPost(id);

            return (post != null) ? Ok(post) : NotFound();
        }

        [HttpPost]
        public IActionResult PostPost([FromBody] PostEntity post)
        {
            if ((post == null) || (_postService.GetPost(post.Id) == null))
            {
                return BadRequest();
            }

            _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new { post = post }, post);
        }

        [HttpPut()]
        public IActionResult UpdatePost(uint id, [FromBody] PostEntity post)
        {
            if (_postService.GetPost(post.Id) == null)
            {
                return BadRequest();
            }

            return _postService.EditPost(id, post.Username, post.Content) ? Ok() : NotFound();
        }

        [HttpDelete]
        public IActionResult DeletePost(uint id, string username)
        {
            if (_postService.DeletePost(id, username))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
