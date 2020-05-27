using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiAppPractice.Data.Entities;

namespace ApiAppPractice.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
