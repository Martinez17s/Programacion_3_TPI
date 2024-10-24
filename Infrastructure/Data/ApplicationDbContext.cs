using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Subject> Subjects => Set<Subject>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configura la herencia TPH (Table Per Hierarchy) para la entidad User y sus derivados
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<User>("User")
                .HasValue<Client>("Client")
                .HasValue<Professor>("Professor")
                .HasValue<Admin>("Admin");
            // Configuración de la conversión de enums
            modelBuilder.Entity<User>()
                    .Property(d => d.Role)
                    .HasConversion(
                        v => v.ToString(),
                        v => (UserRole)Enum.Parse(typeof(UserRole), v));
            // Configuración de las relaciones entre entidades
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Subject)
                .WithMany(a => a.Enrollments)
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            // Configuración de la relación entre Subject y Professor
            modelBuilder.Entity<Subject>()
                .HasOne(a => a.Professor)
                .WithMany(p => p.Subjects)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
