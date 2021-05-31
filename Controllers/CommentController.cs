/**************************************************************************
 *                                                                        *
 *  File:        CommentController.cs                                     *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The REST Route for the comments and sub-comments.        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;

namespace Controllers
{
    /// <summary>
    /// Controller class for the /api/comment REST route
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        /// <summary>
        /// The comment service that holds the user's comments
        /// </summary>
        private static IComment _commentService = new CommentService();
        
        /// <summary>
        /// The user service that tests if an user exists
        /// </summary>
        private static IUser _userService = new UserService();

        /// <summary>
        /// The /api/controller/post/{id} REST route that returs all the comments based on a post id
        /// </summary>
        /// <param name="postId">the post's id</param>
        /// <returns>
        /// Status [NoContent], if a post doesn't have comments<para/>
        /// Status [Ok, Listof(Comments)], if there are comments
        /// </returns>
        [HttpGet("post/{postId}")]
        public IActionResult GetCommentsByPost(uint postId)
        {
            List<CommentEntity> commentsByPost = _commentService.GetCommentsByPostId(postId);

            if (commentsByPost.Count == 0)
            {
                return NoContent();
            }

            return Ok(commentsByPost);
        }

        /// <summary>
        /// Get all the comments
        /// </summary>
        /// <returns>A list with all the comments</returns>
        [HttpGet]
        public IActionResult GetComments()
        {
            List<CommentEntity> comments = _commentService.GetComments();

            return (comments.Count != 0) ? Ok(comments) : NoContent();
        }

        /// <summary>
        /// Gets a comment by an id
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>
        /// Status [NotFound], if the comment doesn't exist <para/>
        /// Status [Ok, CommentEntity]
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult GetComment(uint id)
        {
            CommentEntity comment = _commentService.GetComment(id);

            return (comment != null) ? Ok(comment) : NotFound();
        }

        /// <summary>
        /// Creates a comment
        /// </summary>
        /// <param name="comment">the comment object</param>
        /// <returns>
        /// Status [BadRequest], if the comment is null or the user doesn't exist
        /// Status [200 OK]
        /// </returns>
        [HttpPost]
        public IActionResult PostComment([FromBody] CommentEntity comment)
        {
            if ((comment == null) || (_userService.GetUser(comment.Username) == null))
            {
                return BadRequest();
            }

            _commentService.CreateComment(comment);
            return CreatedAtAction(nameof(GetComment), new { comment = comment }, comment);
        }

        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="id">the comment's id</param>
        /// <param name="comment">the new comment object</param>
        /// <returns>
        /// Status [BadRequest], if the user doesn't exist
        /// Status [Ok]
        /// Status [NotFound], if the comment wasn't found
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult UpdateComment(uint id, [FromBody] CommentEntity comment)
        {
            if (_userService.GetUser(comment.Username) == null)
            {
                return BadRequest();
            }

            return _commentService.EditComment(id, comment.Username, comment.Content) ? Ok() : NotFound();
        }

        /// <summary>
        /// Deletes a comment
        /// </summary>
        /// <param name="id">the comment id</param>
        /// <param name="username">the user's name</param>
        /// <returns>
        /// Status [Ok]
        /// Status [NotFound], if the comment/user doesn't exist, or the user doesn't have rights
        /// </returns>
        [HttpDelete]
        public IActionResult DeleteComment(uint id, string username)
        {
            if (_commentService.DeleteComment(id, username))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
