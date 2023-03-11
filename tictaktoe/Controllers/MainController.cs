using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Google.Protobuf;
using tictaktoe.Model;
using tictaktoe.Services;
using ProtoBuf.Serializers;
using ProtoBuf;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;

namespace tictaktoe.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MainController : ControllerBase
    {
 
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Queue()
        {
            try
            {
                return Ok(GamePlay.Queue());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public ActionResult QueueProto(IFormFile file)
        {
            try
            {
                using (var fileStream = file.OpenReadStream())
                {
                    Serializer.Serialize<int>(fileStream, GamePlay.Queue());

                    return Ok(fileStream);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult GetGame(GameModel gameModel)
        {
            try
            {
                return Ok(GamePlay.GetGame(gameModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult Put(TurnModel data)
        {
            try
            {
                if (data == null)
                {
                    throw new ArgumentException();
                }
                 return Ok(JsonConvert.SerializeObject(GamePlay.MakeTurn(data)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult PutProto(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                try
                {
                    var data = Serializer.Deserialize<TurnModel>(fileStream);
                    if (data == null)
                    {
                        throw new ArgumentException();
                    }
                    Serializer.Serialize<BoardModel>(fileStream, GamePlay.MakeTurn(data));
                    return Ok(fileStream);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpGet]
        public ActionResult GetGameProto(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                try
                {
                    var gameModel = Serializer.Deserialize<GameModel>(fileStream);
                    var outStr = new FileStream("out.proto", FileMode.CreateNew);
                    Serializer.Serialize<BoardModel>(outStr, GamePlay.GetGame(gameModel));
                    return Ok(outStr);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}