/**************************************************************************
 *                                                                        *
 *  File:        PhotoEntity.cs                                         *
 *  Copyright:   (c) 2021, Balan Alexandru-Eduard                         *
 *  E-mail:      edibalan59@gmail.com                                     *
 *  Description: The description of a photo entity sent inside a request* 
 *               body.                                                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Newtonsoft.Json;

namespace Models
{
    public class PhotoEntity
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("path")]
        public string Path { get; set;}

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("phototype")]
        public string PhotoType { get; set; }
        public string Date { get; set; }
    }
}
