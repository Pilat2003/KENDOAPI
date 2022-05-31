using AutoMapper;
using Kendo.Data;
using Kendo.dtos;
using Kendo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Kendo.Controllers
{
    [Authorize]
    [Route("api/Users/[controller]")]
    [ApiController]
    public class UserStatisticController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IcommanderRepo _repository;
        private readonly IJwtAuthenticationManager _authentication;

        public UserStatisticController(IcommanderRepo repo, IMapper mapper, IJwtAuthenticationManager authentication)
        {
            _mapper = mapper;
            _repository = repo;
            _authentication = authentication;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("CheckAuth")]

        public ActionResult res()
        {
            return Ok(Request.Headers[HeaderNames.Authorization].ToString());
        }

        [HttpGet]
        [Route("GetUserStatictic")]
        public ActionResult<UserStatistic> GetUserstatistic()
        {
            Microsoft.Extensions.Primitives.StringValues val;
            if (Request.Headers.TryGetValue(HeaderNames.Authorization, out val) == false) return BadRequest(null);
            string auth = Request.Headers[HeaderNames.Authorization].ToString();
            string key = auth.Substring(7, auth.Length - 7).Trim();

            string token = _authentication.GetIDFromToken(key);

            if (token == null) return null;

            int id = int.Parse(token);

            UserStatistic userStatistic = _repository.GetAllUSerStatisicByUserID(id).FirstOrDefault();
            if (userStatistic == null)
            {
                _repository.PutNewUserStatistic(id);
                userStatistic = _repository.GetAllUSerStatisicByUserID(id).First();
            }

            return Ok(userStatistic);
        }

        [HttpPut]
        [Route("ResetUserStatisticsByUserId")]
        public ActionResult ResetUserStatisticsByUserId(int id )
        {
            _repository.ResetUserStatisticsByUserId(id);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateStaticts/{id}")]
        public ActionResult UpdateStaticticksByUserId(int id,[FromBody] UserStatisticWriteDto data)
        {
            _repository.UpdateUserStatisticsByUserId(id, data);


            return Ok();
        }


    }
}
