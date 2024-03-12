using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class HRDBContext : DbContext
    {
        public HRDBContext() { }

        public HRDBContext(DbContextOptions<HRDBContext> options)
            : base(options) { }

        public virtual DbSet<Aftesi> Aftesis { get; set; } = null!;
        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<Certifikate> Certifikates { get; set; } = null!;
        public virtual DbSet<DetajeUser> DetajeUsers { get; set; } = null!;
        public virtual DbSet<Edukim> Edukims { get; set; } = null!;
        public virtual DbSet<Leje> Lejes { get; set; } = null!;
        public virtual DbSet<PervojePune> PervojePunes { get; set; } = null!;
        public virtual DbSet<Projekt> Projekts { get; set; } = null!;
        public virtual DbSet<PushimetZyrtare> PushimetZyrtares { get; set; } = null!;
        public virtual DbSet<Roli> Rolis { get; set; } = null!;
        public virtual DbSet<UserAftesi> UserAftesis { get; set; } = null!;
        public virtual DbSet<UserCertifikate> UserCertifikates { get; set; } = null!;
        public virtual DbSet<UserEdukim> UserEdukims { get; set; } = null!;
        public virtual DbSet<UserPervojePune> UserPervojePunes { get; set; } = null!;
        public virtual DbSet<UserProjekt> UserProjekts { get; set; } = null!;
        public virtual DbSet<UserRoli> UserRolis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=HRDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aftesi>(entity =>
            {
                entity.ToTable("Aftesi");

                entity.Property(e => e.AftesiId).HasColumnName("aftesiID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.LlojiAftesise).HasMaxLength(30).IsUnicode(false).HasColumnName("llojiAftesise");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__appUser__CB9A1CDF8F4D30CB");

                entity.ToTable("appUser");

                entity.HasIndex(e => e.UserName, "UQ__appUser__66DCF95CC79C3222").IsUnique();

                entity.HasIndex(e => e.UserEmail, "UQ__appUser__D54ADF55A8847270").IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.BalancaLeje).HasColumnName("balancaLeje");

                entity.Property(e => e.UserEmail).HasMaxLength(40).IsUnicode(false).HasColumnName("userEmail");

                entity.Property(e => e.UserFirstname).HasMaxLength(20).IsUnicode(false).HasColumnName("userFirstname");

                entity.Property(e => e.UserIsActive).HasColumnName("userIsActive");

                entity.Property(e => e.UserLastname).HasMaxLength(20).IsUnicode(false).HasColumnName("userLastname");

                entity.Property(e => e.UserName).HasMaxLength(20).IsUnicode(false).HasColumnName("userName");
            });

            modelBuilder.Entity<Certifikate>(entity =>
            {
                entity.HasKey(e => e.CertId).HasName("PK__Certifik__D2C936195927EACA");

                entity.ToTable("Certifikate");

                entity.Property(e => e.CertId).HasColumnName("certID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.CertEmri).HasMaxLength(30).IsUnicode(false).HasColumnName("certEmri");

                entity.Property(e => e.CertPershkrim).HasMaxLength(150).IsUnicode(false).HasColumnName("certPershkrim");
            });

            modelBuilder.Entity<DetajeUser>(entity =>
            {
                entity.HasKey(e => e.Duid).HasName("PK__DetajeUs__2A5FEA6A47A8186E");

                entity.ToTable("DetajeUser");

                entity.Property(e => e.Duid).HasColumnName("DUID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Adresa).HasMaxLength(100).IsUnicode(false).HasColumnName("adresa");

                entity.Property(e => e.ArsyeLargim).HasMaxLength(150).IsUnicode(false).HasColumnName("arsyeLargim");

                entity.Property(e => e.DataFillim).HasColumnType("datetime").HasColumnName("dataFillim");

                entity.Property(e => e.DataLargim).HasColumnType("datetime").HasColumnName("dataLargim");

                entity.Property(e => e.FotoProfili).HasColumnName("fotoProfili");

                entity.Property(e => e.GrupiPunes).HasColumnName("grupiPunes");

                entity.Property(e => e.NumerTelefoni).HasMaxLength(100).IsUnicode(false).HasColumnName("numerTelefoni");

                entity
                    .Property(e => e.PershkrimiVetes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimiVetes");

                entity
                    .Property(e => e.PunaCaktuarNeGrup)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("punaCaktuarNeGrup");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.DetajeUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetajeUse__userI__5070F446");
            });

            modelBuilder.Entity<Edukim>(entity =>
            {
                entity.HasKey(e => e.EduId).HasName("PK__Edukim__84C108B2C0AC4738");

                entity.ToTable("Edukim");

                entity.Property(e => e.EduId).HasColumnName("eduID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.EduName).HasMaxLength(30).IsUnicode(false).HasColumnName("eduName");
            });

            modelBuilder.Entity<Leje>(entity =>
            {
                entity.ToTable("Leje");

                entity.Property(e => e.LejeId).HasColumnName("lejeID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Aprovuar).HasColumnName("aprovuar");

                entity.Property(e => e.DataFillim).HasColumnType("datetime").HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim).HasColumnType("datetime").HasColumnName("dataMbarim");

                entity.Property(e => e.TipiLeje).HasMaxLength(30).IsUnicode(false).HasColumnName("tipiLeje");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.Lejes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leje__userID__5812160E");
            });

            modelBuilder.Entity<PervojePune>(entity =>
            {
                entity.HasKey(e => e.Ppid).HasName("PK__PervojeP__5FD889CDF743D3CD");

                entity.ToTable("PervojePune");

                entity.Property(e => e.Ppid).HasColumnName("PPID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ppemri).HasMaxLength(30).IsUnicode(false).HasColumnName("PPEmri");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.ToTable("Projekt");

                entity.Property(e => e.ProjektId).HasColumnName("projektID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmriProjekt).HasMaxLength(30).IsUnicode(false).HasColumnName("emriProjekt");

                entity
                    .Property(e => e.PershkrimProjekt)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimProjekt");
            });

            modelBuilder.Entity<PushimetZyrtare>(entity =>
            {
                entity.HasKey(e => e.PushimId).HasName("PK__Pushimet__2ABEFD9AEC47125E");

                entity.ToTable("PushimetZyrtare");

                entity.Property(e => e.PushimId).ValueGeneratedNever().HasColumnName("pushimId");

                entity.Property(e => e.Dita).HasColumnType("datetime").HasColumnName("dita");

                entity
                    .Property(e => e.PershkrimiDita)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimiDita");
            });

            modelBuilder.Entity<Roli>(entity =>
            {
                entity.ToTable("Roli");

                entity.Property(e => e.RoliId).HasColumnName("roliID").HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoliEmri).HasMaxLength(20).IsUnicode(false).HasColumnName("roliEmri");

                entity.Property(e => e.RoliPershkrim).HasMaxLength(150).IsUnicode(false).HasColumnName("roliPershkrim");
            });

            modelBuilder.Entity<UserAftesi>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AftesiId }).HasName("PK__user_Aft__1FF18DB3217E96B2");

                entity.ToTable("user_Aftesi");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.AftesiId).HasColumnName("aftesiID");

                entity.Property(e => e.DataPerfitimit).HasColumnType("datetime").HasColumnName("dataPerfitimit");

                entity
                    .HasOne(d => d.Aftesi)
                    .WithMany(p => p.UserAftesis)
                    .HasForeignKey(d => d.AftesiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Afte__aftes__412EB0B6");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.UserAftesis)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Afte__userI__403A8C7D");
            });

            modelBuilder.Entity<UserCertifikate>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CertId }).HasName("PK__user_Cer__46B68FBE85F1B063");

                entity.ToTable("user_Certifikate");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.CertId).HasColumnName("certID");

                entity.Property(e => e.DataFituar).HasColumnType("datetime").HasColumnName("dataFituar");

                entity.Property(e => e.DataSkadence).HasColumnType("datetime").HasColumnName("dataSkadence");

                entity.Property(e => e.DokumentCertifikate).HasColumnName("dokumentCertifikate");

                entity
                    .HasOne(d => d.Cert)
                    .WithMany(p => p.UserCertifikates)
                    .HasForeignKey(d => d.CertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Cert__certI__48CFD27E");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.UserCertifikates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Cert__userI__47DBAE45");
            });

            modelBuilder.Entity<UserEdukim>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EduId }).HasName("PK__user_Edu__F3D60C54E85E2150");

                entity.ToTable("user_Edukim");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.EduId).HasColumnName("eduID");

                entity.Property(e => e.DataFillim).HasColumnType("datetime").HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim).HasColumnType("datetime").HasColumnName("dataMbarim");

                entity.Property(e => e.DokumentDiplome).HasColumnName("dokumentDiplome");

                entity.Property(e => e.LlojiMaster).HasMaxLength(30).IsUnicode(false).HasColumnName("llojiMaster");

                entity.Property(e => e.Mesatarja).HasColumnName("mesatarja");

                entity
                    .HasOne(d => d.Edu)
                    .WithMany(p => p.UserEdukims)
                    .HasForeignKey(d => d.EduId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Eduk__eduID__44FF419A");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.UserEdukims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Eduk__userI__440B1D61");
            });

            modelBuilder.Entity<UserPervojePune>(entity =>
            {
                entity.HasKey(e => new { e.Ppid, e.UserId }).HasName("PK__user_Per__B3612800028F8AEA");

                entity.ToTable("user_PervojePune");

                entity.Property(e => e.Ppid).HasColumnName("PPID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.DataFillim).HasColumnType("datetime").HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim).HasColumnType("datetime").HasColumnName("dataMbarim");

                entity
                    .Property(e => e.Konfidencialiteti)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("konfidencialiteti");

                entity
                    .Property(e => e.PershkrimiPunes)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("pershkrimiPunes");

                entity.Property(e => e.Pppozicion).HasMaxLength(30).IsUnicode(false).HasColumnName("PPPozicion");

                entity
                    .HasOne(d => d.Pp)
                    .WithMany(p => p.UserPervojePunes)
                    .HasForeignKey(d => d.Ppid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Pervo__PPID__4BAC3F29");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.UserPervojePunes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Perv__userI__4CA06362");
            });

            modelBuilder.Entity<UserProjekt>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjektId }).HasName("PK__user_Pro__8CEF50C8E4DD5FB3");

                entity.ToTable("user_Projekt");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.ProjektId).HasColumnName("projektID");

                entity.Property(e => e.DataFillim).HasColumnType("datetime").HasColumnName("dataFillim");

                entity.Property(e => e.DataMbarim).HasColumnType("datetime").HasColumnName("dataMbarim");

                entity
                    .HasOne(d => d.Projekt)
                    .WithMany(p => p.UserProjekts)
                    .HasForeignKey(d => d.ProjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Proj__proje__3D5E1FD2");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.UserProjekts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Proj__userI__3C69FB99");
            });

            modelBuilder.Entity<UserRoli>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoliId }).HasName("PK__user_Rol__0435B99A44DA6CDC");

                entity.ToTable("user_Roli");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.RoliId).HasColumnName("roliID");

                entity.Property(e => e.DataCaktimit).HasColumnType("datetime").HasColumnName("dataCaktimit");

                entity
                    .HasOne(d => d.Roli)
                    .WithMany(p => p.UserRolis)
                    .HasForeignKey(d => d.RoliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Roli__roliI__5441852A");

                entity
                    .HasOne(d => d.User)
                    .WithMany(p => p.UserRolis)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_Roli__userI__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
