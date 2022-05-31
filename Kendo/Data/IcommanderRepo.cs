using Kendo.Models;
using Kendo.dtos;
using System.Collections.Generic;

namespace Kendo.Data
{
    public interface IcommanderRepo
    {
        public string checkDatabase();
        public void SaveChanges();


        #region users
        public IEnumerable<User> GetAllUsers();
        public User GetUserByUsername(string username);
        public bool CheckIfUserExistsByEmail(string email);
        public bool CheckIfUserExistsByID(int id);

        public User GetUserById(int id);

        public User GetUserByEmail(string email);

        public void PutNewUser(User user);

        #endregion users


        #region UserStatistic

        public bool CheckIfUserStatisticExistsByEmail(string email);
        public bool CheckIfUserStatisticxistsByID(int id); 

        public IEnumerable<UserStatistic> GetAllUSerStatisics();

        public IEnumerable<UserStatistic> GetAllUSerStatisicByUserID(int id);

        public void PutNewUserStatistic(int id);

        public UserStatistic GetUSerStatisicksByuserId(string id);

        public UserStatistic GetUSerStatisicksByEmail(string email);

        public void ResetUserStatisticsByUserId(int id);

        public void UpdateUserStatisticsByUserId(int id, UserStatisticWriteDto data);

        #endregion UserStatistic



        #region BattleStatistics
         IEnumerable<BattleStatistic> GetAllBattleStatistics();

         IEnumerable<BattleStatistic> GetAllBattleStatisticsByUSerId(int id);

         BattleStatistic GetBattleStatisticsById(int id);

         BattleStatistic GetBattleStatisticsByEmail(string email);

         void ResetBattleStatisticByUserId(int id);


        void PutNewBattleStatistic(BattleStatistic user);

        #endregion BattleStatistics
    }
}
