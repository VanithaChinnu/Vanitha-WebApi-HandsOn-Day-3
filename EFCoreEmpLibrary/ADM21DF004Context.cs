using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreEmpLibrary
{
    public partial class ADM21DF004Context : DbContext
    {
        public ADM21DF004Context()
        {
        }

        public ADM21DF004Context(DbContextOptions<ADM21DF004Context> options)
            : base(options)
        {
        }

        public virtual DbSet<EMPL> EMPLs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; database=ADM21DF004; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EMPL>(entity =>
            {
                entity.HasKey(e => e.EID)
                    .HasName("PK__Employee__AF2DBB995C0BD1CF");

                entity.ToTable("EMPL");

                entity.HasIndex(e => e.EmpName, "ENAME_IDX");

                entity.Property(e => e.EID).ValueGeneratedNever();

                entity.Property(e => e.DoBirth).HasColumnType("date");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
