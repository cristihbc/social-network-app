/**************************************************************************
 *                                                                        *
 *  File:        IPhoto.cs                                                *
 *  Copyright:   (c) 2021, Balan Alexandru-Eduard                         *
 *  E-mail:      edibalan59@gmail.com                                     *
 *  Description: The interface for the photo service.                     *
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
    public interface IPhoto
    {
        /// <summary>
        /// Creates a new photo
        /// </summary>
        /// <param name="photo">the comment entity that holds the data</param>
        /// <returns>
        /// true - if the photo was created<para/>
        /// false - if the photo wasn't created<para/>
        /// The photo can't be created if the user that requested the action doesn't exist
        /// </returns>
        bool CreatePhoto(PhotoEntity photo);
        /// <summary>
        /// Returns all the photos
        /// </summary>
        /// <returns>a list with photoentity objects</returns>
        List<PhotoEntity> GetPhotos();
        /// <summary>
        /// Gets a specific photo with the id provided
        /// </summary>
        /// <param name="id">the id of the requested photo</param>
        /// <returns>the photo or null if it doesn't exist</returns>
        PhotoEntity GetPhoto(uint id);

        /// <summary>
        /// Changes the content of a photo and the timestamp only if the 
        /// specified user has edit rights
        /// </summary>
        /// <param name="id">the id of the photo</param>
        /// <param name="username"></param>
        /// <param name="description">the new content of the photo</param>
        /// <returns>true if the photo was changed, false otherwise</returns>
        bool EditPhoto(uint id, string username, string description);
        /// <summary>
        /// Deletes a photo if the user has rights
        /// </summary>
        /// <param name="id">the id of the photo</param>
        /// <param name="username"></param>
        /// <returns>true if the photo was deleted, false otherwise</returns>
        bool DeletePhoto(uint id, string username);
        /// <summary>
        /// Checks if a photo exists
        /// </summary>
        /// <param name="id">the id of the photo</param>
        /// <returns>true if it exists, false otherwise</returns>
        bool Exists(uint id);
        /// <summary>
        /// Checks if an user has rights for a photo
        /// </summary>
        /// <param name="id">the id of the photo</param>
        /// <param name="username"></param>
        /// <returns>true if the user has rights, false otherwise</returns>
        bool HasRights(uint id, string username);

    }
}
