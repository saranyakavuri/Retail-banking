using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace retailbank.Models
{

    [MetadataType(typeof(loginmetadata))]
    public partial class logincastle_3
    {

    }
    public class loginmetadata
    {
        public int loginid { get; set; }
        
        [MinLength(8)]
        [Required(ErrorMessage = "Please Enter valid username")]
        [RegularExpression("^(?=.*[A-Za-z])[A-Za-z0-9]{8,}$", ErrorMessage = "Only alphanumeric or alpha minimum 8")]
        public string username { get; set; }
      
        [MinLength(10)]
     
        [Required(ErrorMessage = "Please Enter leave valid password")]

        public string password { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
    }
}