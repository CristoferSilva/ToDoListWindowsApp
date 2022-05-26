using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons.Entities;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace Commons.Services
{
    public class ToDoListDB : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, "data.db")}");
    }
}
