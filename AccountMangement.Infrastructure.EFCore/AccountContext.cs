﻿using AccountMangement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using AccountingManagement.Domain.AccountAgg;
using AccountingManagement.Domain.RoleAgg;

namespace AccountMangement.Infrastructure.EFCore
{
    public class AccountContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
