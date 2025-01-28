using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APISandbox__Blanca_Segura.Models;

public partial class LenguajesC27403Context : DbContext
{
    private readonly IConfiguration _configuration;


    public LenguajesC27403Context(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected LenguajesC27403Context()
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<GetAllStudentsView> GetAllStudentsViews { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<GetAllStudentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetAllStudentsView");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.NationalityId).HasColumnName("Nationality_Id");
            entity.Property(e => e.NationalityName)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(30);
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.ToTable("Nationality");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.NationalityId).HasColumnName("Nationality_Id");
            entity.Property(e => e.Password).HasMaxLength(30);

            entity.HasOne(d => d.Nationality).WithMany(p => p.Students)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK_Student_Nationality");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
