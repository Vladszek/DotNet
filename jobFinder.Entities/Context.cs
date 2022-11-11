using Microsoft.EntityFrameworkCore;
using jobFinder.Entities.Models;

namespace jobFinder.Entities;
public class Context : DbContext {
    public DbSet<City>? Cities { get; set; }
    public DbSet<CV>? CVs { get; set; }
    public DbSet<CVForVacancy>? CVForVacancies { get; set; }
    public DbSet<EmploymentType>? EmploymentTypes { get; set; }
    public DbSet<UserEmployee>? UserEmployees { get; set; }
    public DbSet<UserEmployer>? UserEmployers { get; set; }
    public DbSet<Vacancy>? Vacancies { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Cities

        builder.Entity<City>().ToTable("cities");
        builder.Entity<City>().HasKey(x => x.Id);

        #endregion

        #region CVs

        builder.Entity<CV>().ToTable("CVs");
        builder.Entity<CV>().HasKey(x => x.Id);
        builder.Entity<CV>().HasOne(x => x.UserEmployee)
                                    .WithMany(x => x.CVs)
                                    .HasForeignKey(x => x.UserEmployeeID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region CVForVacancies

        builder.Entity<CVForVacancy>().ToTable("CVForVacancies");
        builder.Entity<CVForVacancy>().HasKey(x => x.Id);
        builder.Entity<CVForVacancy>().HasOne(x => x.CV)
                                    .WithMany(x => x.CVForVacancies)
                                    .HasForeignKey(x => x.CVID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<CVForVacancy>().HasOne(x => x.Vacancy)
                                    .WithMany(x => x.CVForVacancies)
                                    .HasForeignKey(x => x.VacancyID)
                                    .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region EmploymentTypes

        builder.Entity<EmploymentType>().ToTable("employmentTypes");
        builder.Entity<EmploymentType>().HasKey(x => x.Id);

        #endregion

        #region UserEmployees

        builder.Entity<UserEmployee>().ToTable("userEmployees");
        builder.Entity<UserEmployee>().HasKey(x => x.Id);
        builder.Entity<UserEmployee>().HasOne(x => x.City)
                                    .WithMany(x => x.UserEmployees)
                                    .HasForeignKey(x => x.CityID)
                                    .OnDelete(DeleteBehavior.Cascade);
        
        #endregion

        #region UserEmployers

        builder.Entity<UserEmployer>().ToTable("userEmployers");
        builder.Entity<UserEmployer>().HasKey(x => x.Id);
        builder.Entity<UserEmployer>().HasOne(x => x.City)
                                    .WithMany(x => x.UserEmployers)
                                    .HasForeignKey(x => x.CityID)
                                    .OnDelete(DeleteBehavior.NoAction);

        #endregion

        #region Vacancies

        builder.Entity<Vacancy>().ToTable("vacancies");
        builder.Entity<Vacancy>().HasKey(x => x.Id);
        builder.Entity<Vacancy>().HasOne(x => x.City)
                                    .WithMany(x => x.Vacancies)
                                    .HasForeignKey(x => x.CityID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Vacancy>().HasOne(x => x.EmploymentType)
                                    .WithMany(x => x.Vacancies)
                                    .HasForeignKey(x => x.EmploymentTypeID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Vacancy>().HasOne(x => x.UserEmployer)
                                    .WithMany(x => x.Vacancies)
                                    .HasForeignKey(x => x.UserEmployerID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}