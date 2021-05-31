/**************************************************************************
 *                                                                        *
 *  File:        FactoryBuilder.cs                                        *
 *  Copyright:   (c) 2021, Balan Alexandru-Eduard                         *
 *  E-mail:      edibalan59@gmail.com                                     *
 *  Description: A factory builder that constructs all the factory design *
 *               patterns.                                                *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

namespace Commons
{
    /// <summary>
    /// Class that returns a factory based on the argument provided
    /// </summary>
   public class FactoryBuilder
    {
        /// <summary>
        /// Method that returns a factory
        /// </summary>
        /// <param name="type">the factory's type</param>
        /// <returns>A FriendFactory or null</returns>
        public static AbstractFactory GetFactory(string type)
        {
            if (type.Equals("friend"))
                return new FriendFactory();
            return null;
        }
    }
}
