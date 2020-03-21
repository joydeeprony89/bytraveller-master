//---------------------------------------------------------------------------------------------
// <copyright file= BaseModel.cs company= ByTraveller>
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

    public abstract class BaseModel
    {
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}
