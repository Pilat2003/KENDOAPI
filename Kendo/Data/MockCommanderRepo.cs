using Kendo.dtos;
using Kendo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Data
{
    public class MockCommanderRepo : IcommanderRepo
    {
        public static IEnumerable<User> seed()
        {
            List<User> list = new List<User>();

            User x = new User()
            {
                Id = 1,
                Username = "a",
                Email = "Tomek126@gmail.com",
                Password = "a",
                UserStatistics = new UserStatistic()
                {
                    AllHits = 40,
                    CorrectHits = 15,
                    Wins = 3,
                    Loses = 2
                },
                Statistics = new List<BattleStatistic>()
                {
                    new BattleStatistic()
                    {
                        CreatedOn= new System.DateTime(2022, 05, 27, 8, 30, 0),
                        AllHits = 14,
                        Timespan = new System.TimeSpan(0,6,30),
                        hits = JsonConvert.SerializeObject(new List<Hit>()
                        {
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Hidari_Do},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Migi_Do},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Hidari_Kote},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Kote},
                        }),
                        Won = true
                    },
         new BattleStatistic()
        {
             CreatedOn= new System.DateTime(2022, 05, 27, 9, 30, 0),
            AllHits = 14,
                        Timespan = new System.TimeSpan(0, 6, 30),
                        hits = JsonConvert.SerializeObject(new List<Hit>()
                        {
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Hidari_Do},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Migi_Do},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Hidari_Kote},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Kote},
                        }),
                        Won = true
        },
                new BattleStatistic()
                {
                    CreatedOn= new System.DateTime(2022, 05, 27, 10, 30, 0),
                    AllHits = 14,
                    Timespan = new System.TimeSpan(0, 6, 30),
                    hits = JsonConvert.SerializeObject(new List<Hit>()
                        {
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Hidari_Do},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Migi_Do},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Hidari_Kote},
                            new Hit(){ BodyPart = BattleStatistic.BodyPart.Kote},
                        }),
                    Won = true
                }
            }

            };
            list.Add(x);
            return list;
        }

        public string checkDatabase()
        {
            throw new System.NotImplementedException();
        }

        public string checkDatabase(string s)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfUserExistsByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfUserExistsByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfUserStatisticExistsByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfUserStatisticxistsByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BattleStatistic> GetAllBattleStatistics()
        {
            throw new System.NotImplementedException();
        }

        public UserStatistic GetAllBattleStatisticsByUSerId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserStatistic> GetAllUSerStatisicByUserID(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserStatistic> GetAllUSerStatisicks()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserStatistic> GetAllUSerStatisics()
        {
            throw new System.NotImplementedException();
        }

        public BattleStatistic GetBattleStatisticsByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public BattleStatistic GetBattleStatisticsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public UserStatistic GetUSerStatisicksByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public UserStatistic GetUSerStatisicksByuserId(string id)
        {
            throw new System.NotImplementedException();
        }

        public void PutNewBattleStatistic(BattleStatistic user)
        {
            throw new System.NotImplementedException();
        }

        public void PutNewUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void PutNewUserStatistic(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ResetBattleStatisticByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ResetUserStatisticsByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpDataUserStatisticsByUserId(int id, UserStatisticWriteDto data)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserStatisticsByUserId(int id, UserStatisticWriteDto data)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<BattleStatistic> IcommanderRepo.GetAllBattleStatisticsByUSerId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}



 