//---------------------------------------------------------------------------------------------
// <copyright file= HeaderMainMenu.cs company= ByTraveller>
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

    public class HeaderMainMenu : BaseModel
    {
        public int HeaderMainMenuId { get; set; }
        [MaxLength(100)]
        [DisplayName("Main Menu")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Menu Position")]
        [Required]
        public int Index { get; set; }

        [DisplayName("Active")]
        [Required]
        public bool IsActive { get; set; }

        public ICollection<HeaderSubMenu> HeaderSubMenus { get; set; }

    }
}
