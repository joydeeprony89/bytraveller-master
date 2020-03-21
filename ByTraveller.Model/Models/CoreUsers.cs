using System;
using System.Collections.Generic;
using System.Text;

namespace ByTraveller.Model.Models
{
    /// <summary>
    /// Core Users Details Model
    /// </summary>
    public class CoreUsers : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
