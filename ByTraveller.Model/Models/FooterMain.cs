//---------------------------------------------------------------------------------------------
// <copyright file= Footer.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Footer : BaseModel
    {
        public int FooterId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string CopyRightText { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }

        public ICollection<SocialWebSite> SocialWebSites { get; set; }
    }
}
