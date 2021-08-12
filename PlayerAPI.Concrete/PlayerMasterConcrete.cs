using Microsoft.Extensions.Configuration;
using PlayerAPI.Interface;
using PlayerAPI.Models;
using PlayerAPI.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlayerAPI.Concrete
{
    public class PlayerMasterConcrete : IPlayerMaster
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public PlayerMasterConcrete(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public bool AddPlayer(PlayerMaster playerMaster)
        {
            _context.PlayerMasters.Add(playerMaster);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdatePlayer(PlayerMaster playerMaster)
        {
            var playerMasterData = (from playerMasters in _context.PlayerMasters
                                    where playerMasters.PlayerId == playerMaster.PlayerId
                                    select playerMasters).FirstOrDefault();

            if (playerMasterData.PlayerId > 0)
            {
                playerMasterData.PlayerName = playerMaster.PlayerName;
                playerMasterData.Dob = playerMaster.Dob;
                playerMasterData.PlayerType = playerMaster.PlayerType;
                playerMasterData.CountryID = playerMaster.CountryID;
                playerMasterData.TotalMatch = playerMaster.TotalMatch;
                playerMasterData.TotalRun = playerMaster.TotalRun;
                playerMasterData.TotalCentury = playerMaster.TotalCentury;
                playerMasterData.TotalFifty = playerMaster.TotalFifty;
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool RemovePlayer(PlayerMaster playerMaster)
        {
            var playerMasterData = (from playerMasters in _context.PlayerMasters
                                    where playerMasters.PlayerId == playerMaster.PlayerId
                                    select playerMasters).FirstOrDefault();
            if (playerMasterData != null)
            {
                _context.PlayerMasters.Remove(playerMasterData);
                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<PlayerMasterVM> GetPlayer()
        {
            var result = (from usertb in _context.PlayerMasters
                          select new PlayerMasterVM()
                          {
                              PlayerName = usertb.PlayerName,
                              Dob = usertb.Dob,
                              PlayerType = usertb.PlayerType,
                              Country = usertb.CountryID,
                              TotalMatch = usertb.TotalMatch,
                              TotalRun = usertb.TotalRun,
                              TotalCentury = usertb.TotalCentury,
                              TotalFifty = usertb.TotalFifty
                          }).ToList();

            return result;
        }
    }
}
