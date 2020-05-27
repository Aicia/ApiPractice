using ApiAppPractice.Data.Entities;
using System.Collections.Generic;

namespace ApiAppPractice.Data
{
    public interface IAppRepository
    {
        Account GetAccById(string id);
        IEnumerable<Account> GetAllAcc();
        bool UpdateAcc();
        void AddEntity(Account acc);
        void SaveAll();
        void EditAcc(Account acc);
        void DeleteAcc(string id);
    }
}