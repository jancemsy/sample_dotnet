using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Soundbite.TokenGen;

namespace reach_soundbite_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string encKey = "SHARED_ENC_KEY_HERE";
            string orgRoute = "dkxsT7lE";
            string userEmail = "admin@ltapac.onmicrosoft.com";

            TokenServiceSettings settings = new TokenServiceSettings()
            {
                Config = encKey,
                TokenTimeoutInMinutes = 60
            };

            ITokenService service = new TokenServiceSecretKey(settings);
            string token = service.GenerateToken("SomeIssuer", orgRoute, userEmail);

            return Ok("our new token is ==>" + token);
        }

        [HttpPost]
        public IActionResult Post(JObject jObject)
        {
            return Ok(jObject);

        }

    }
}