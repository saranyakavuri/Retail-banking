using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace retailbank.Models
{

    [MetadataType(typeof(accountmetadata))]
    public partial class castleaccount33
    {
        public List<SelectListItem> acctype { get; set; }
        public List<SelectListItem> cidlist { get; set; }
        [Range(1, 100000000, ErrorMessage = "Please enter valid deposit amount")]
        public int depositamount { get; set; }
        [Range(1, 100000000, ErrorMessage = "Please enter valid withdrawl amount")]
        public int withdrawlamount { get; set; }
        public int accid1 { get; set; }
        public int accid2 { get; set; }
        [Required]
         [Range(1,100000000,ErrorMessage ="Please enter valid amount")]
        public int amount { get; set; }
        public List<SelectListItem> srcac { get; set; }
        public List<SelectListItem> tgtac { get; set; }
    }
    public class accountmetadata
    {
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Please enter valid CustomerId")]
        public Nullable<int> CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter valid Account Type")]
        public string AccountType { get; set; }
        [Required(ErrorMessage = "Please enter balance")]
        public Nullable<int> Balance { get; set; }

        public Nullable<System.DateTime> lastupdated { get; set; }
        public string ShowMessage { get; set; }
        public string AccountStatus { get; set; }


        public virtual Custdet_1288 Custdet_1288 { get; set; }
    }
}