using Commons.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWPF.Model.Database
{
    public class TasksDatabase : ToDoListDB
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"DataSource=C:\Users\cristofer.s\AppData\Local\Packages\628dbe3f-e2fe-49f0-986a-8fec4288765d_5ev0r293b6err\LocalState\data.db");

    }
}
