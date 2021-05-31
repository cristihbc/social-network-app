/**************************************************************************
 *                                                                        *
 *  File:        FriendFactory.cs                                         *
 *  Copyright:   (c) 2021, Balan Alexandru-Eduard                         *
 *  E-mail:      edibalan59@gmail.com                                     *
 *  Description: The implementation of an abstract factory.               *
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

namespace Commons
{
    /// <summary>
    /// Implementation class for building a factory design pattern
    /// </summary>
    public class FriendFactory : AbstractFactory
    {
        /// <summary>
        /// Returns a friend based on the close factor
        /// </summary>
        /// <param name="IsClose">"close" if he/she is close or "not close"</param>
        /// <param name="data">the FriendEntity object</param>
        /// <returns>a new FriendEntity with the close factor filled</returns>
        public override FriendEntity GetFriend(string IsClose , FriendEntity data)
        {
            bool check = false;
            if(IsClose.Equals("close"))
            {
                check = true;
            }
            return new FriendEntity { IsClose = check , Username = data.Username };
        }
    }
}
