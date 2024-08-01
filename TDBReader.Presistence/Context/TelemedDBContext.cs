using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TDBReader.Domain.Entities.dbEntities;

namespace TDBReader.Presistence.Context;

public partial class TelemedDBContext : DbContext
{
    public TelemedDBContext()
    {
    }

    public TelemedDBContext(DbContextOptions<TelemedDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<ProcessMetadatum> ProcessMetadata { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("context_type", new[] { "unknown", "role", "process" })
            .HasPostgresExtension("uuid-ossp");


        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("process_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.Metadata).WithMany(p => p.Processes)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_metadata_id");
        });

        modelBuilder.Entity<ProcessMetadatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("process_metadata_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.Process).WithMany(p => p.ProcessMetadata)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_process_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
