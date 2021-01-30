using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessContacts.Models;

namespace BusinessContacts.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessContacts.Models.ContactDataModel> ContactDataModel { get; set; }
    }
}
