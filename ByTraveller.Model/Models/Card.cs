//---------------------------------------------------------------------------------------------
// <copyright file= Card.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Card : BaseModel
    {
        public int CardId { get; set; }

        [DisplayName("Card Name")]
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [MaxLength(1000)]
        [Required]
        public string ShortDescription { get; set; }

        [DisplayName("Active")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Menu Item")]
        public int SubMenuItemId { get; set; }

        [DisplayName("Menu Item")]
        public SubMenuItem SubMenuItem { get; set; }

        [DisplayName("Profile Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        [DisplayName("Profile Image")]
        public bool ImageUploaded { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public CardDetail CardDetail { get; set; }

    }
}
