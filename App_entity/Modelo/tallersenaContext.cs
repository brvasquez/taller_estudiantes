//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace App_entity.Modelo
//{
//    public partial class tallersenaContext : DbContext
//    {
//        public virtual DbSet<Estudiante> Estudiante { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseMySql("Server=localhost; userid=root; password=; Database=tallersena");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Estudiante>(entity =>
//            {
//                entity.HasKey(e => e.Codigo);

//                entity.ToTable("estudiantes");

//                entity.Property(e => e.Codigo).HasColumnName("codigo");

//                entity.Property(e => e.Correo)
//                    .HasColumnName("correo")
//                    .HasMaxLength(30);

//                entity.Property(e => e.Nombre)
//                    .HasColumnName("nombre")
//                    .HasMaxLength(45);

//                entity.Property(e => e.Nota1).HasColumnName("nota1");

//                entity.Property(e => e.Nota2).HasColumnName("nota2");

//                entity.Property(e => e.Nota3).HasColumnName("nota3");
//            });
//        }
//    }
//}
