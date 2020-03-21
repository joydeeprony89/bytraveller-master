namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SubMenuItem
    {
        public int SubMenuItemId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Sub Menu")]
        public int HeaderSubMenuId { get; set; }

        [DisplayName("Sub Menu")]
        public HeaderSubMenu HeaderSubMenu { get; set; }

        public ICollection<Card> Cards { get; set; }


    }
}
