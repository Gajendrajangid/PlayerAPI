using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayerAPI.Models
{
    public class PlayerMaster
    {
        [Key]
        public int PlayerId { set; get; }
        public string PlayerName { set; get; }
        public string Dob { set; get; }
        public int PlayerType { set; get; }
        public int CountryID { set; get; }
        public int TotalMatch { set; get; }
        public int TotalRun { set; get; }
        public int TotalCentury { set; get; }
        public int TotalFifty { set; get; }
    }
}
