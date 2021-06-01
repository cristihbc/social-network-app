/**************************************************************************
 *                                                                        *
 *  File:        CommentService.cs                                        *
 *  Copyright:   (c) 2021, Balan Alexandru-Eduard                         *
 *  E-mail:      edibalan59@gmail.com                                     *
 *  Description: The service that manages the photo operations flow.      *
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
    public class PhotoService : IPhoto, IGenericService
    {
        private static Dictionary<uint, PhotoEntity> _photos = new Dictionary<uint, PhotoEntity>();

        /// <summary>
        /// Creates a new photo
        /// </summary>
        /// <param name="photo">the photo entity that holds the data</param>
        /// <returns>
        /// true - if the photo was created<para/>
        /// false - if the photo wasn't created<para/>
        /// The comment can't be created if the user that requested the action doesn't exist
        /// </returns>
        public bool CreatePhoto(PhotoEntity photo)
        {
            if (!Exists(photo.Id))
            {
                photo.Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                _photos.Add(photo.Id, photo);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes a photo if the user has rights
        /// </summary>
        /// <param name="Photoid">the id of the photo</param>
        /// <param name="username"></param>
        /// <returns>true if the photo was deleted, false otherwise</returns>
        public bool DeletePhoto(uint Photoid, string username)
        {
            if (HasRights(Photoid, username))
            {
                _photos.Remove(Photoid);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Changes the content of a photo and the timestamp only if the 
        /// specified user has edit rights
        /// </summary>
        /// <param name="id">the id of the comment</param>
        /// <param name="username"></param>
        /// <param name="description">the new content of the photo</param>
        /// <returns>true if the photo was changed, false otherwise</returns>
        public bool EditPhoto(uint id, string username, string description)
        {
            if (HasRights(id, username))
            {
                _photos[id].Description = description;
                _photos[id].Date = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a photo exists
        /// </summary>
        /// <param name="id">the id of the photo</param>
        /// <returns>true if it exists, false otherwise</returns>
        public bool Exists(uint id)
        {
            return _photos.ContainsKey(id);
        }

        /// <summary>
        /// Gets a specific photo with the id provided
        /// </summary>
        /// <param name="id">the id of the requested photo</param>
        /// <returns>the photo or null if it doesn't exist</returns>
        public PhotoEntity GetPhoto(uint id)
        {
            return Exists(id) ? _photos[id] : null;
        }

        /// <summary>
        /// Returns all the photos
        /// </summary>
        /// <returns>a list with PhotoEntity objects</returns>
        public List<PhotoEntity> GetPhotos()
        {
            return _photos.Values.ToList();
        }

        /// <summary>
        /// Checks if an user has rights for a Photo
        /// </summary>
        /// <param name="id">the id of the photo</param>
        /// <param name="username"></param>
        /// <returns>true if the user has rights, false otherwise</returns>
        public bool HasRights(uint id, string username)
        {
            return Exists(id) && _photos[id].Username.Equals(username);
        }

        /// <summary>
        /// Deletes all data that a service holds
        /// </summary>
        public void PurgeData()
        {
            _photos.Clear();
        }
    }
}
