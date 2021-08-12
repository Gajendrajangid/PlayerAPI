using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerAPI.ViewModels
{
    public class PlayerMasterVM
    {
        public int PlayerId { set; get; }
        public string PlayerName { set; get; }
        public string PlayerTypeName { set; get; }
        public string CountryName { set; get; }
        public string Dob { set; get; }
        public int PlayerType { set; get; }
        public int Country { set; get; }
        public int TotalMatch { set; get; }
        public int TotalRun { set; get; }
        public int TotalCentury { set; get; }
        public int TotalFifty { set; get; }
    }
}
