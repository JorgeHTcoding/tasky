using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasky.Models;

namespace tasky.DataAccess
{
    public class TaskyDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public TaskyDBContext(DbContextOptions<TaskyDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }
        public virtual DbSet<UserModel>? User { get; set; }
        public virtual DbSet<ProjectModel>? Project { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<TaskyDBContext>();

            optionsBuilder
                .UseMySql("server=myshoulder.cdvg9i8dvcl6.eu-west-3.rds.amazonaws.com;port=3306;user=ComboWombo;password=ComboWombo123!;database=TaskyServer;convert zero datetime=True",
                ServerVersion.AutoDetect("server=myshoulder.cdvg9i8dvcl6.eu-west-3.rds.amazonaws.com;port=3306;user=ComboWombo;password=ComboWombo123!;database=TaskyServer;convert zero datetime=True"))
                .LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        }

    }

