using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAppPractice.Data.Entities;

namespace ApiAppPractice.Data
{
    public class AppRepository : IAppRepository
    {
        public readonly AccountContext _ctx;

        public AppRepository(AccountContext ctx)
        {
            _ctx = ctx;
        }

        public Account GetAccById(string id)
        {
            Account acc = _ctx.Accounts.Where(x => x.user_id == id).FirstOrDefault();

            if (acc != null)
            {
                return acc;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Account> GetAllAcc()
        {
            return _ctx.Accounts.ToList();
        }

        public void EditAcc(Account acc)
        {
            _ctx.Update(acc);
        }

        public bool UpdateAcc()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(Account acc)
        {
            _ctx.Add(acc);
        }

        public void SaveAll()
        {
            _ctx.SaveChanges();
        }

        public void DeleteAcc(string id)
        {
            var acc = _ctx.Accounts.Where(x => x.user_id.Equals(id)).FirstOrDefault();
            _ctx.Remove(acc);
        }
    }
}
