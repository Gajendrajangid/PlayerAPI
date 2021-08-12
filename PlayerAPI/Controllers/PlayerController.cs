using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerAPI.Interface;
using PlayerAPI.Models;
using PlayerAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using PlayerAPI.Interface;

namespace PlayerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerMaster _player;
        public PlayerController(IPlayerMaster player)
        {
            _player = player;
        }

        [HttpGet]
        public IEnumerable<PlayerMasterVM> Get()
        {
            try
            {
                return _player.GetPlayer();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] PlayerMaster playermaster)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    _player.AddPlayer(playermaster);
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest
                    };
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
