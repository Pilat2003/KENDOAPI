using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kendo.Data;
using System.Collections.Generic;
using Kendo.Models;
using System.Text.RegularExpressions;
using Kendo.dtos;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;

namespace Kendo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IcommanderRepo _repository;
        private readonly IJwtAuthenticationManager _authentication;

        public UsersController(IcommanderRepo repo, IMapper mapper, IJwtAuthenticationManager Authentication)
        {
            _mapper = mapper;
            _repository = repo;
            _authentication = Authentication;
        }

        private User UserGetByTokenBerer()
        {
            string auth = Request.Headers[HeaderNames.Authorization].ToString();
            string key = auth.Substring(7, auth.Length - 7).Trim();

            string token = _authentication.GetIDFromToken(key);

            if(token == null) return null;

            int id = int.Parse(token);
            return _repository.GetUserById(id);
        }




        [HttpPost]
        [Route("PutNewUser")]
        private ActionResult PutNewUser([FromBody] UserWriteDto data)
        {
            

            //Walidacja
            if (data.Email == null) return BadRequest();
            if (data.Password == null) return BadRequest();
            if (data.Username == null) return BadRequest();


            if (!IsEmailValid(data.Email)) return BadRequest();

            if (_repository.CheckIfUserExistsByEmail(data.Email))
            {
                return StatusCode(403, "Already Exists");
            }

            User user = _mapper.Map<User>(data);
            _repository.PutNewUser(user);
            _repository.SaveChanges();
            return Accepted();
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route("LogIN")]
        public ActionResult<string> LogMeIn(string Username, string password)
        {
            //Check();
            if (Username == null) return BadRequest();
            if (password == null) return BadRequest();



            User u = _repository.GetUserByUsername(Username);
            if (u == null) return Unauthorized();
            if (u.Password != password) return Unauthorized();

            string token = _authentication.MakeNewToken(Username, u.Id.ToString());

            if (token == null) return Unauthorized();



            return Ok(token);
            return "fda";
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("SignIN")]
        public ActionResult<string> SignMeIN(string email, string password, string username)
        {
            return PutNewUser(new UserWriteDto() { Email = email, Password = password, Username = username });
        }


        private bool IsEmailValid(string email)
        {
            Regex validation = new Regex("@");
            return validation.IsMatch(email);

        }






        [AllowAnonymous]
        [HttpGet]
        [Route("CheckConnection")]
        public ActionResult<string> Check()
        {
           
            return Ok(_repository.checkDatabase());
           
        }





    }
}
