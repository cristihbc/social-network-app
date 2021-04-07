/**************************************************************************
 *                                                                        *
 *  File:        UserServiceUnitTest.cs                                   *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Unit test class for the UserService based on the AAA     *
 *               Pattern                                                  *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace UnitTests
{
    [TestClass]
    public class UserServiceUnitTest
    {
        private UserService userService = new UserService();

        [TestMethod]
        public void UsersListSizeShouldBeZero()
        {
            // Arrange
            int usersListSize;
            int expectedSize = 0;

            // Act
            usersListSize = userService.GetUsers().Count;

            // Assert
            Assert.AreEqual(expectedSize, usersListSize);
        }
    }
}
