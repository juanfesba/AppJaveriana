using System;
using Microsoft.EntityFrameworkCore;
using AppJaveriana.Modelos;
using Xamarin.Forms;

namespace MVVMXamarin.Services
{
    public class DataBase : DbContext
    {
        private readonly string rutaBD;

        private DbSet<SessionModel> SessionModelDB { get; set; }
        private DbSet<UserModel> UserModelDB { get; set; }
        private DbSet<CourseModel> CourseModelDB { get; set; }
        private DbSet<CourseScheduleModel> CourseScheduleModelDB { get; set; }



        public DataBase(string rutaDB)
        {
            this.rutaBD = rutaDB;
            Database.EnsureCreated();
        }

        //Metodos
        //Getters y Setters

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDataBase>().GetDatabasePath(); //learnentityframeworkcore.com
            optionsBuilder.UseSqlite($"Filename={dbPath}");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionModel>().HasKey(p => p.sessionModelID);
            modelBuilder.Entity<UserModel>().HasKey(p => p.userModelID);
            modelBuilder.Entity<CourseModel>().HasKey(p => p.courseModelID);
            modelBuilder.Entity<CourseScheduleModel>().HasKey(p => p.CourseScheduleModelID);
        }

    }
}
