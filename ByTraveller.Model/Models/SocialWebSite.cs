//---------------------------------------------------------------------------------------------
// <copyright file= SocialWebSite.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SocialWebSite : BaseModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string SiteRedirectUrl { get; set; }
        [MaxLength(500)]
        public string SiteToken { get; set; }
        public int ImageId { get; set; }
        public bool IsActive { get; set; }
    }
}
