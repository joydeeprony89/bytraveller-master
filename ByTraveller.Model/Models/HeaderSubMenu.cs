//---------------------------------------------------------------------------------------------
// <copyright file= HeaderSubMenu.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class HeaderSubMenu : BaseModel
    {
        public int HeaderSubMenuId { get; set; }

        [MaxLength(200)]
        [DisplayName("Sub Menu")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Menu Position")]
        [Required]
        public int Index { get; set; }

        [DisplayName("Is Active")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Main Menu")]
        public int HeaderMainMenuId { get; set; }

        [DisplayName("Main Menu")]
        public HeaderMainMenu HeaderMainMenu { get; set; }
        public ICollection<SubMenuItem> SubMenuItems { get; set; }

    }
}
