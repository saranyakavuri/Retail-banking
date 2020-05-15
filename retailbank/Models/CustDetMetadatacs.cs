using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace retailbank.Models
{
    [MetadataType(typeof(CustDetMetadatacs))]
    public partial class Custdet_1288
    {

        public List<SelectListItem> lst2 { get; set; }
        public List<SelectListItem> lst1 { get; set; }

    }

    public class CustDetMetadatacs
    {
        [Key]
        public int custid { get; set; }
        [Required(ErrorMessage = "please enter the customerSSNID")]
        //[RegularExpression("^[0-9]{8-8}$", ErrorMessage = "ssn id should be 8 digits")]
        //[Required]
        //[MaxLength(5)]
        //[MinLength(5)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "ssn id should be 9 digits")]
        public Nullable<long> custSsnId { get; set; }
        
        [Required(ErrorMessage = "please enter the customerName")]
        public string custName { get; set; }
        [Required(ErrorMessage = "please enter the customerAge")]
        [Range(0, 100, ErrorMessage = "please enter a valid age")]
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "please enter the TemporaryAddress")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "please enter the permnantAddress")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "please enter the city")]
        public string city { get; set; }
        [Required(ErrorMessage = "please enter the state")]
        public string state { get; set; }
        public Nullable<System.DateTime> lastupdated { get; set; }
        public string DisplayMessage { get; set; }
        public string AccountStatus { get; set; }


    }
}