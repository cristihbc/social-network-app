/**************************************************************************
 *                                                                        *
 *  File:        PostServiceUnitTest.cs                                   *
 *  Copyright:   (c) 2021, Barbu Bogdan-Cosmin                            *
 *  E-mail:      barbubogdan1337@gmail.com                                *
 *  Description: Class that holds the test methods for the post           *
 *               service.                                                 *
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
using Models;
using Services;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class PostServiceUnitTest
    {
        private PostService postService = new PostService();

        private List<PostEntity> postPool = new List<PostEntity>()
        {
            new PostEntity()
            {
                Id = 1,
                Username = "WE TESTING",
                Content = "THIS IS MY POST BERBERITA"
            },
            new PostEntity()
            {
                Id = 2,
                Username = "TESTING NR 2 LETS GOO",
                Content = "Turn into a convertible"
            }
        };

        [TestMethod]
        public void PostListShouldBeZero()
        {
            // Arrange
            int postsLength;
            int expectedLength = 0;

            // Act
            postsLength = postService.GetPosts().Count;

            // Assert
            Assert.AreEqual(postsLength, expectedLength);
        }

        [TestMethod]
        public void DoesTheKeyExist()
        {
            // Arrange
            uint id = 1;
            bool result;

            // Act
            result = postService.Exists(id);

            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CreateANewPost()
        {
            // Arrange
            bool result;

            // Act
            result = postService.CreatePost(postPool[0]);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        [TestMethod]
        public void CannotCreatePostsWithTheSameId()
        {
            // Arrange
            bool result;

            // Act
            postService.CreatePost(postPool[0]);
            result = postService.CreatePost(postPool[0]);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        [TestMethod]
        public void DoesTheUserHaveRightsForThePostPositive()
        {
            // Arrange
            uint id = 1;
            string username = "test";
            bool result;

            PostEntity post = new PostEntity()
            {
                Id = id,
                Username = username
            };


            // Act
            postService.CreatePost(post);
            result = postService.HasRights(id, username);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        [TestMethod]
        public void GetAPostWithIdNull()
        {
            // Arrange
            uint id = 2;
            PostEntity result;

            // Act
            result = postService.GetPost(id);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAPostWithIdPositive()
        {
            // Arrange
            const int index = 0;
            string expectedString = postPool[index].Content;
            PostEntity result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.GetPost(postPool[index].Id);

            // Assert
            Assert.AreEqual(result.Content, expectedString);

            postService.PurgeData();
        }

        [TestMethod]
        public void DeletePostWithNoRights()
        {
            // Arrange
            const int index = 1;
            string username = "testing";
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.DeletePost(postPool[index].Id, username);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        [TestMethod]
        public void DeletePostWithRights()
        {
            // Arrange
            const int index = 1;
            string username = postPool[index].Username;
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.DeletePost(postPool[index].Id, username);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }

        [TestMethod]
        public void EditPostWithNoRights()
        {
            // Arrange
            const int index = 1;
            string username = "no user";
            string content = "nothing";
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.EditPost(postPool[index].Id, username, content);

            // Assert
            Assert.IsFalse(result);

            postService.PurgeData();
        }

        [TestMethod]
        public void EditPostWitRights()
        {
            // Arrange
            const int index = 1;
            string username = postPool[index].Username;
            string content = "nothing";
            bool result;

            // Act
            postService.CreatePost(postPool[index]);
            result = postService.EditPost(postPool[index].Id, username, content);

            // Assert
            Assert.IsTrue(result);

            postService.PurgeData();
        }
    }
}