using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models;

public partial class ToDoAppContext : DbContext
{
    public ToDoAppContext()
    {
    }

    public ToDoAppContext(DbContextOptions<ToDoAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //=> optionsBuilder.UseSqlServer("Server=DESKTOP-FBGOG4O\\TODOAPP;Database=ToDoApp;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Task");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Naslov).HasMaxLength(50);
            entity.Property(e => e.Opis).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
