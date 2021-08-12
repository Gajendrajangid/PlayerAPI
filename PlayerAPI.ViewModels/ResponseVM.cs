using System;

namespace PlayerAPI.ViewModels
{
    public class ResponseVM
    {
        public object Data { set; get; }
        public int Status { set; get; }
        public String Message { set; get; }
    }
}
