using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todo.Entities.Models;

namespace Todo.Entities;

public partial class TodoAppContext : DbContext
{
    public TodoAppContext(DbContextOptions<TodoAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoCollection> TodoCollections { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Todos");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(512);

            entity.HasOne(d => d.User).WithMany(p => p.TodoCollections)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Todos_Users");
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TodoEntry");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.TodoCollection).WithMany(p => p.TodoItems)
                .HasForeignKey(d => d.TodoCollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TodoItems_TodoCollections");

            entity.HasOne(d => d.User).WithMany(p => p.TodoItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TodoItems_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.DisplayName).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(128);
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
