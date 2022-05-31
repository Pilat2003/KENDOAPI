using AutoMapper;
using Kendo.Data;
using Kendo.dtos;
using Kendo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kendo.Controllers
{
    [Authorize]
    [Route("/api/Users/[controller]")]
    [ApiController]
    public class BattleStatisticController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IcommanderRepo _repository;
        private readonly IJwtAuthenticationManager _authentication;

        public BattleStatisticController(IcommanderRepo repo, IMapper mapper, IJwtAuthenticationManager authentication)
        {
            _mapper = mapper;
            _repository = repo;
            _authentication = authentication;
        }


        [HttpGet]
        [Route("GetAllBattleStatistic")]
        public ActionResult<IEnumerable<BattleStatistic>> GetAllBattleStatistic()
        {
            string auth = Request.Headers[HeaderNames.Authorization].ToString();
            string key = auth.Substring(7, auth.Length - 7).Trim();
            string token = _authentication.GetIDFromToken(key);
            if (token == null) return Unauthorized();
            int id = int.Parse(token);
            return Ok(_repository.GetAllBattleStatisticsByUSerId(id));
        }


        [HttpPost]
        [Route("PutNewBattleStatistic")]
        public ActionResult PutNewBattleStatistic([FromBody] BattleStatisticWriteDto data)
        {
            string auth = Request.Headers[HeaderNames.Authorization].ToString();
            string key = auth.Substring(7, auth.Length - 7).Trim();

            string token = _authentication.GetIDFromToken(key);

            if (token == null) return Unauthorized();
            int id = int.Parse(token);


            //Zapisz nową BattleStatistic
            BattleStatistic stat = _mapper.Map<BattleStatistic>(data);
            stat.hits = JsonConvert.SerializeObject(data.hits);
            stat.UserId = id;
            stat.CreatedOn = DateTime.Now;
            _repository.PutNewBattleStatistic(stat);
            //A teraz update UserStatistic
            UserStatisticWriteDto UserStat = new UserStatisticWriteDto()
            {
                AllHits = stat.AllHits,
                CorrectHits = stat.hits.Length,
                Wins = stat.Won == false ? 1 : 0,
                Loses = stat.Won == true ? 1 : 0,
                userId = stat.UserId,
                
            };
            _repository.UpdateUserStatisticsByUserId(id, UserStat);
            _repository.SaveChanges();
            return Ok();
            //JsonConvert.SerializeObject(data.hits)
           
        }
}
}
