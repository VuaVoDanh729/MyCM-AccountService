using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountModel.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccountInfrastructure.context
{
    public class AccountContext : DbContext
    {
        private const string _booleanType = "bool";
        private const string _intType = "int";
        private const string _stringType100  = "varchar(100)";
        private const string _dateType  = "datetime";

        public AccountContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(a => {
                a.HasKey(a => a.Id);
                a.Property(a => a.Id).IsRequired().HasColumnType(_stringType100);
                a.Property(a => a.Username).IsRequired().HasColumnType(_stringType100);
                a.Property(a => a.Password).IsRequired().HasColumnType(_stringType100).IsConcurrencyToken();
                a.Property(a => a.CreatedDate).IsRequired().HasColumnType(_dateType);
            });

            modelBuilder.Entity<AccountHistory>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Id).IsRequired().HasColumnType(_stringType100);
                a.Property(a => a.AccountId).IsRequired().HasColumnType(_stringType100);
                a.Property(a => a.OldPassword).IsRequired().HasColumnType(_stringType100);
                a.Property(a => a.ModifyDate).IsRequired().HasColumnType(_dateType);
            });

            modelBuilder.Entity<AccountHistory>()
                .HasOne(a => a.Account)
                .WithMany(a => a.AccountHistories)
                .HasForeignKey(a => a.AccountId);
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountHistory> AccountHistories { get; set; }

    }
}
