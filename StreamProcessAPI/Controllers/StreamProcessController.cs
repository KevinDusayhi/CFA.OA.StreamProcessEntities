using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CFA.OA.StreamProcessEntities;
using CFA.OA.StreamProcessServices;

namespace StreamProcessAPI.Controllers
{
    public class StreamProcessController : ApiController
    {
        private IParseService _parseService;

        public StreamProcessController(IParseService parseServicecs)
        {
            _parseService = parseServicecs;
        }

        [HttpPost]
        [Route("api/Parse")]
        public IHttpActionResult Post(InputParameter input)
        {
            if (input == null)
            {
                return BadRequest();
            }
            try
            {
                var score = _parseService.ParseToScore(input.value);
                OutputContent content = new OutputContent(score);
            
                return Ok(content);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
