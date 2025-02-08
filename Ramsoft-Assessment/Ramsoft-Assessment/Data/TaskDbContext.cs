using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using Ramsoft_Assessment.modal;
using Task = Ramsoft_Assessment.modal.Task;

namespace WebApi.Data.Repository.DataBase
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskBoard> Faculties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
