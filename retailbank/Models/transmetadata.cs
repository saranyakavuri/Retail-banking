using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace retailbank.Models
{
    [MetadataType(typeof(transmetadata))]
    public partial class transaction33
    {

    }
    public class transmetadata
    {

        public long TransactionId { get; set; }
        public Nullable<int> TransAccountId { get; set; }
        public string TransDescription { get; set; }
        public Nullable<System.DateTime> Transdate { get; set; }
        [Range(1, 9999999999, ErrorMessage = "please enter a valid amount")]
        public Nullable<long> TransAmount { get; set; }

        public virtual castleaccount33 castleaccount33 { get; set; }
    }
}