//---------------------------------------------------------------------------------------------
// <copyright file= CountryState.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CountryState : BaseModel
    {
        public int CountryStateId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string StateCode { get; set; }
        public bool IsActive { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<StateCity> StateCities { get; set; }
    }
}
