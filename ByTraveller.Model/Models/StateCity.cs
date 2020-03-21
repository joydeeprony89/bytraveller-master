//---------------------------------------------------------------------------------------------
// <copyright file= StateCity.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

namespace ByTraveller.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class StateCity : BaseModel
    {
        public int StateCityId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string CityCode { get; set; }
        public int Index { get; set; }
        public bool IsActive { get; set; }

        public int CountryStateId { get; set; }
    }
}
