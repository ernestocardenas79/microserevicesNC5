﻿using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                var savedDate = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.CreatedDate = savedDate;
                        entry.Entity.CreatedBy = "swn";
                        entry.Entity.LastModifiedDate = savedDate;
                        entry.Entity.LastModifiedBy = "swn";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = savedDate;
                        entry.Entity.CreatedBy = "swn";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
