using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthorizeFilter.Models
{
    public class LoginUser
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="UserName Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
    }
}