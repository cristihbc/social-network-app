/**************************************************************************
 *                                                                        *
 *  File:        PostController.cs                                        *
 *  Copyright:   (c) 2021, Barbu Bogdan-Cosmin                            *
 *  E-mail:      barbubogdan1337@gmail.com                                *
 *  Description: Describes the REST API routes for the post data.         *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

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

        [HttpGet]
        public IActionResult GetPosts()
        {
            List<PostEntity> posts = _postService.GetPosts();

            return (posts.Count != 0) ? Ok(posts) : NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(uint id)
        {
            PostEntity post = _postService.GetPost(id);

            return (post != null) ? Ok(post) : NotFound();
        }

        [HttpPost]
        public IActionResult PostPost([FromBody] PostEntity post)
        {
            if (post == null) 
            {
                return BadRequest();
            }

            _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new { post = post }, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(uint id, [FromBody] PostEntity post)
        {
            if (_postService.GetPost(post.Id) == null)
            {
                return BadRequest();
            }

            return _postService.EditPost(id, post.Username, post.Content) ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
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
