/**************************************************************************
 *                                                                        *
 *  File:        IUser.cs                                                 *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Interface for the user service class                     *
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
    public interface IUser
    {
        /// <summary>
        /// Method that returns an user based on the username provided
        /// </summary>
        /// <param name="username">username of the searched user</param>
        /// <returns>the searched user</returns>
        UserEntity GetUser(string username);

        /// <summary>
        /// Returns all the users stored
        /// </summary>
        /// <returns>the list of requested users</returns>
        List<UserEntity> GetUsers();

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="user">a user object filled with the required properties</param>
        /// <returns>
        /// true if the user has been created<para/>
        /// false if the user wasn't created
        /// </returns>
        bool CreateUser(UserEntity user);

        /// <summary>
        /// Updates an user
        /// </summary>
        /// <param name="username">the id</param>
        /// <param name="user">the user entity</param>
        /// <returns>
        /// true if the user has been updated<para/>
        /// false if the user wasn't updated
        /// </returns>
        bool UpdateUser(string username, UserEntity user);

        /// <summary>
        /// Deletes an user
        /// </summary>
        /// <param name="username">the id</param>
        /// <returns>
        /// true if the user has been deleted<para/>
        /// false if the user wasn't deleted
        /// </returns>
        bool DeleteUser(string username);
    }
}
