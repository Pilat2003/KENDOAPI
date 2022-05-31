using AutoMapper;
using Kendo.dtos;
using Kendo.Models;
using Kendo.dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Kendo.Data
{
    public class CommanderRepo : IcommanderRepo
    {
        private readonly IMapper _mapper;
        private readonly KendoDBContext _context;

        public CommanderRepo(KendoDBContext context, IMapper mapper) 
        {
            _mapper = mapper;
            _context = context;
               
        }

        public CommanderRepo()
        {
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }



        #region User

        #region TestFunctions
        

        public IEnumerable<User> GetAllUsers()
        {
           return _context.Users;
        }

        public bool CheckIfUserExistsByEmail(string email)
        {
            User user = (from Userq in _context.Users
                         where Userq.Email == email
                         select Userq).ToList().FirstOrDefault();

            if (user == null) return false;
            return true;
        }

        public bool CheckIfUserExistsByID(int id)
        {
            User user = (from Userq in _context.Users
                         where Userq.Id == id
                         select Userq).ToList().FirstOrDefault();
            if (user == null) return false;
            return true;
        }

        public User GetUserByUsername(string username)
        {
            User user = (from Userq in _context.Users
                         where Userq.Username == username
                         select Userq).ToList().FirstOrDefault();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user = (from Userq in _context.Users
                         where Userq.Email == email
                         select Userq).ToList().FirstOrDefault();

            if (user == null) return null;

            UserStatistic querryForUserStats = (from stats in _context.UserStatistics
                                                where stats.userId == user.Id
                                                select new UserStatistic
                                                {

                                                    AllHits = stats.AllHits,
                                                    CorrectHits = stats.CorrectHits,
                                                    Id = stats.Id,
                                                    Loses = stats.Loses,
                                                    userId = stats.userId,
                                                    Wins = stats.Wins
                                                }).ToList().FirstOrDefault();
            var querryForBattleStats = (from battle in _context.BattleStatistics where battle.UserId == user.Id select battle).ToList();

           

            if (querryForUserStats != null)
            {
                user.UserStatistics = (UserStatistic)querryForUserStats;
            }
            if (querryForBattleStats != null)
            {
                user.Statistics = (List<BattleStatistic>)querryForBattleStats;
            }
            return user;
        }

        public User GetUserById(int id)
        {
            User user= (from Userq in _context.Users where Userq.Id == id select new User
            {
                Id = Userq.Id,
                Email = Userq.Email,
                Password = Userq.Password,
                Statistics = Userq.Statistics,
                Username = Userq.Username,
                UserStatistics = Userq.UserStatistics
            }).ToList().FirstOrDefault();

            UserStatistic querryForUserStats = (from stats in _context.UserStatistics where stats.userId == id select new UserStatistic
            {
                
                AllHits = stats.AllHits,
                CorrectHits = stats.CorrectHits,
                Id = stats.Id,
                Loses = stats.Loses,
                userId = stats.userId,
                Wins = stats.Wins
            }).ToList().FirstOrDefault();
            var querryForBattleStats = (from battle in _context.BattleStatistics where battle.UserId == id select battle).ToList();

            if (user== null) return null;


            if (querryForUserStats != null)
            {
                user.UserStatistics = (UserStatistic)querryForUserStats;
            }
            if (querryForBattleStats != null)
            {
                user.Statistics = (List<BattleStatistic>)querryForBattleStats;
            }
            return user;
        }

        #endregion TestFunctions

        

        public void PutNewUser(User user)
        {
            _context.Users.Add(user);
        }
        #endregion User

        #region UserStatistics       



        public bool CheckIfUserStatisticExistsByEmail(string email)
        {
            UserStatistic stat = (from x in _context.UserStatistics
                                  join u in _context.Users on x.userId equals u.Id
                                  where u.Email == email
                                  select x).FirstOrDefault();
            if (stat == null) return false;
            return true;

        }

        public bool CheckIfUserStatisticxistsByID(int id)
        {
            UserStatistic stats = (from stat in _context.UserStatistics
                         where stat.Id == id
                         select stat).ToList().FirstOrDefault();
            if (stats == null) return false;
            return true;
        }


        public IEnumerable<UserStatistic> GetAllUSerStatisicks()
        {
            List<UserStatistic> Stats = (from x in _context.UserStatistics select x).ToList();
            return Stats;
        }


        public UserStatistic GetUSerStatisicksByEmail(string email)
        {
            UserStatistic Stats = (from x in _context.UserStatistics
                                         join u in _context.Users on x.userId equals u.Id
                                         where u.Email == email select x).FirstOrDefault();
            return Stats;
        }

        public UserStatistic GetUSerStatisicksByuserId(string id)
        {
            UserStatistic Stats = (from x in _context.UserStatistics
                                   join u in _context.Users on x.userId equals u.Id
                                   where u.Id.ToString() == id
                                   select x).FirstOrDefault();
            return Stats;
        }

        public void ResetUserStatisticsByUserId(int id)
        {
            UserStatistic Stats = (from x in _context.UserStatistics
                                                where x.userId == id
                                                select x).ToList().First();

            _context.UserStatistics.Remove(Stats);
            _context.UserStatistics.Add(new UserStatistic() { userId = id });
            _context.SaveChanges();

        }

        public void PutNewUserStatistic(int id)
        {
            UserStatistic us = new UserStatistic();
            us.userId = id;

            _context.UserStatistics.Add(us);
            SaveChanges();
        }

        public void UpdateUserStatisticsByUserId(int id, UserStatisticWriteDto data)
        {
            UserStatistic us = GetAllUSerStatisicByUserID(data.userId).FirstOrDefault();

            if (us == null) PutNewUserStatistic(id);
            us = GetAllUSerStatisicByUserID(data.userId).FirstOrDefault();
            if (data.Wins == 0)
            {
                us.Wins += 1; 
            }
            else
            {
                us.Loses += 1;
            }

            us.userId = id;
            us.AllHits += data.AllHits;
            us.CorrectHits = data.CorrectHits;
            us.AllHits = data.AllHits;
            //us.CorrectHits = data.hits.Count();
          

            _context.UserStatistics.Update(us);
            SaveChanges();
        }
        public IEnumerable<UserStatistic> GetAllUSerStatisics()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserStatistic> GetAllUSerStatisicByUserID(int id)
        {
            IEnumerable<UserStatistic> tab = (from x in _context.UserStatistics
                                                where x.userId == id
                                                select x).ToList();


            return tab;
        }



        #endregion UserStatistics

        #region BattleStatistics
        public IEnumerable<BattleStatistic> GetAllBattleStatistics()
        {
            return _context.BattleStatistics.ToList();
        }

        public IEnumerable<BattleStatistic> GetAllBattleStatisticsByUSerId(int id)
        {
            IEnumerable<BattleStatistic> tab = (from x in _context.BattleStatistics
                                                where x.UserId == id
                                                select x).ToList();

            return tab;
        }


        public BattleStatistic GetBattleStatisticsById(int id)
        {
            BattleStatistic stat = (from x in _context.BattleStatistics
                                    where x.Id == id
                                    select x).First();

            return stat;
        }

        public BattleStatistic GetBattleStatisticsByEmail(string email)
        {
            BattleStatistic stat = (from x in _context.BattleStatistics
                                    join user in _context.Users on x.Id equals user.Id
                                    where user.Email == email
                                    select x).First();

            return stat;
        }

        public void PutNewBattleStatistic(BattleStatistic stat)
        {
            _context.BattleStatistics.Add(stat);
        }

        public void ResetBattleStatisticByUserId(int id)
        {
            IEnumerable<BattleStatistic> Stats = (from x in _context.BattleStatistics
                                                  where x.UserId == id
                                                  select x).ToList();
            _context.RemoveRange(Stats);
            _context.SaveChanges();
        }

        public string checkDatabase()
        {
            if (_context.Database.CanConnect())
            {
                _context.Database.OpenConnection();
                return "connected";
            }
            else
            {
                _context.Database.SetConnectionString("Data Source=localhost;User ID=Test;Password=asdfg;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=Kendo;");

                if (_context.Database.CanConnect())
                {
                    _context.Database.OpenConnection();
                    return "connected2";
                }
                else
                {
                    return "not connected 2";
                }


                return _context.Database.GetConnectionString();
            }
                
        }

        public string checkDatabase(string s)
        {
            throw new System.NotImplementedException();
        }

        #endregion BattleStatistics
    }
}
