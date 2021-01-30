using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessContacts.Models;

namespace BusinessContacts.Data
{
    public class BusinessContactsContext : DbContext
    {
        public BusinessContactsContext (DbContextOptions<BusinessContactsContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessContacts.Models.ContactDataModel> ContactDataModel { get; set; }
    }
}
