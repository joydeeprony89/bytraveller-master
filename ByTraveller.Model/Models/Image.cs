//---------------------------------------------------------------------------------------------
// <copyright file= Image.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using ByTraveller.Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ByTraveller.Model.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        [DisplayName("Image Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Image Type")]
        [Required]
        public ImageType ImageType { get; set; } //1.ProfileImage 2. MainSlider 3. CardSlider

        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
