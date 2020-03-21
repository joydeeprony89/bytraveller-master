//---------------------------------------------------------------------------------------------
// <copyright file= Country.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Country : BaseModel
    {
        public int CountryId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }

        public ICollection<CountryState> CountryStates { get; set; }
    }
}
