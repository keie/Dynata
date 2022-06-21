using Application.Interfaces;
using Domain.Common;
using Domain.DynataSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext:DbContext
    {
        public readonly IDateTimeService _dateTime;

        public DbSet<FileObj>? File { get; set; }

        public DbSet<Folder>? Folder { get; set; }

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            /*ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;*/
        }

        /*public override Task <int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created=_dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
