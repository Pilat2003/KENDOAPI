using Kendo.Models;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kendo.Data
{
    public class Seeder
    {
        private readonly KendoDBContext _dBContext;

        public Seeder(KendoDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Seed()
        {
            if (_dBContext.Database.CanConnect())
            {
                if (!_dBContext.Users.Any())
                {
                    List<User> list = new List<User>();

                    User x = new User()
                    {
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

                    _dBContext.Users.AddRange(list);
                    _dBContext.SaveChanges();
                }
            }
        }
    }
}
