//---------------------------------------------------------------------------------------------
// <copyright file= CardDetail.cs company= ByTraveller>
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

    public class CardDetail : BaseModel
    {
        public int CardDetailId { get; set; }

        [DisplayName("Card Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required]
        public string PlaceDescription { get; set; }

        [DisplayName("Places To Stay")]
        public string PlacesToStay { get; set; }

        [DisplayName("Places To Visit")]
        public string PlacesToVisit { get; set; }

        [DisplayName("Places To Eat")]
        public string PlacesToEat { get; set; }

        [DisplayName("Local Food")]
        public string LocalFood { get; set; }

        public string Activities { get; set; }

        public bool HasReview { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
