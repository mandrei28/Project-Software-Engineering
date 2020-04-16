using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.DataAccess
{
    public class TenantsAssociationDbContext : DbContext
    {
        public TenantsAssociationDbContext(DbContextOptions<TenantsAssociationDbContext> options) : base(options)
        {
        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollResults> PollResults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
    }
}
