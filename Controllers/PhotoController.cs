/**************************************************************************
 *                                                                        *
 *  File:        UserController.cs                                        *
 *  Copyright:   (c) 2021, Balan Alexandru-Eduard                         *
 *  E-mail:      edibalan59@gmail.com                                     *
 *  Description: Describes the REST API routes for the photo data.        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using System.Collections.Generic;
using Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private static IPhoto _PhotosService = new PhotoService();
        private static IUser _userService = new UserService();

        [HttpGet]
        public IActionResult GetPhotos()
        {
            List<PhotoEntity> photos = _PhotosService.GetPhotos();

            return (photos.Count != 0) ? Ok(photos) : NoContent();
        }

        [HttpGet("{photoID}")]
        public IActionResult GetPhoto(uint id)
        {
            PhotoEntity photo = _PhotosService.GetPhoto(id);

            return (photo != null) ? Ok(photo) : NotFound();
        }

        [HttpPost]
        public IActionResult PostPhoto([FromBody] PhotoEntity photo)
        {
            if (photo == null) 
            {
                return BadRequest();
            }

            _PhotosService.CreatePhoto(photo);
            return CreatedAtAction(nameof(GetPhoto), new { photo = photo }, photo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePhoto(uint id, [FromBody] PhotoEntity photo)
        {
            if (photo == null)
            {
                return BadRequest();
            }

            return _PhotosService.EditPhoto(id, photo.Username, photo.Description) ? Ok() : NotFound();
        }

        [HttpDelete]
        public IActionResult DeletePhoto(uint id, string username)
        {
            if (_PhotosService.DeletePhoto(id, username))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
