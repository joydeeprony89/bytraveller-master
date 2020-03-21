//---------------------------------------------------------------------------------------------
// <copyright file= ImageCollection.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ImageCollection
    {
        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public byte ImageType { get; set; } // 1. MainSlide, 2.CardSlider, 3.Image
        public int Index { get; set; }
        public bool IsActive { get; set; }
    }
}
