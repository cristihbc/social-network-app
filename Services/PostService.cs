/**************************************************************************
 *                                                                        *
 *  File:        CommentService.cs                                        *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: The service that manages the comments operations flow.   *
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
using Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Services
{
    public class PostService : IPost, IGenericService
    {
        private static Dictionary<uint, PostEntity> _posts = new Dictionary<uint, PostEntity>();

        public bool CreatePost(PostEntity post)
        {
            if (!Exists(post.Id))
            {
                post.Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                _posts.Add(post.Id, post);
                return true;
            }

            return false;
        }


        public bool DeletePost(uint id, string username)
        {
            if (HasRights(id, username))
            {
                _posts.Remove(id);
                return true;
            }

            return false;
        }


        public bool EditPost(uint id, string username, string content)
        {
            if (HasRights(id, username))
            {
                _posts[id].Content = content;
                _posts[id].Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                return true;
            }

            return false;
        }


        public bool Exists(uint id)
        {
            return _posts.ContainsKey(id);
        }


        public PostEntity GetPost(uint id)
        {
            return Exists(id) ? _posts[id] : null;
        }


        public List<PostEntity> GetPosts()
        {
            return _posts.Values.ToList();
        }


        public bool HasRights(uint id, string username)
        {
            return Exists(id) && _posts[id].Username.Equals(username);
        }


        public void PurgeData()
        {
            _posts.Clear();
        }
    }
}