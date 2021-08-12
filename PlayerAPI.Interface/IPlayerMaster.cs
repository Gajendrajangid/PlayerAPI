using PlayerAPI.Models;
using PlayerAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerAPI.Interface
{
   public interface IPlayerMaster
    {
        List<PlayerMasterVM> GetPlayer();
        bool AddPlayer(PlayerMaster obj);
        bool UpdatePlayer(PlayerMaster obj);
        bool RemovePlayer(PlayerMaster obj);
    }
}
