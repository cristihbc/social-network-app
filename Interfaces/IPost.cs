/**************************************************************************
 *                                                                        *
 *  File:        IComment.cs                                              *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The interface for the comment service.                   *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPost
    {
        /// <summary>
        /// Creates a new post
        /// </summary>
        /// <param name="post">the post entity that holds the data</param>
        /// <returns>
        /// true - if the post was created<para/>
        /// false - if the post wasn't created<para/>
        /// The post can't be created if the user that requested the action doesn't exist
        /// </returns>
        bool CreatePost(PostEntity post);

        /// <summary>
        /// Returns all the posts
        /// </summary>
        /// <returns>a list with PostEntity objects</returns>
        List<PostEntity> GetPosts();

        /// <summary>
        /// Gets a specific post with the id provided
        /// </summary>
        /// <param name="id">the id of the requested post</param>
        /// <returns>the post or null if it doesn't exist</returns>
        PostEntity GetPost(uint id);

        /// <summary>
        /// Changes the content of a post and the timestamp only if the specified user has edit rights
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <param name="username"></param>
        /// <param name="content">the new content of the post</param>
        /// <returns>true if the post was changed, false otherwise</returns>
        bool EditPost(uint id, string username, string content);

        /// <summary>
        /// Deletes a post if the user has rights
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <param name="username"></param>
        /// <returns>true if the post was deleted, false otherwise</returns>
        bool DeletePost(uint id, string username);

        /// <summary>
        /// Checks if a post exists
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <returns>true if it exists, false otherwise</returns>
        bool Exists(uint id);

        /// <summary>
        /// Checks if an user has rights for a post
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <returns>true if the user has rights, false otherwise</returns>
        bool HasRights(uint id, string username);
    }
}