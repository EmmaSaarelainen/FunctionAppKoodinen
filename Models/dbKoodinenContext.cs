using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class dbKoodinenContext : DbContext
    {
        public string ConnectionString { get; set; }
        public dbKoodinenContext(string connectionstring)
        {
            ConnectionString = connectionstring;
        }

        public dbKoodinenContext(DbContextOptions<dbKoodinenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kayttaja> Kayttaja { get; set; }
        public virtual DbSet<Kurssi> Kurssi { get; set; }
        public virtual DbSet<KurssiSuoritus> KurssiSuoritus { get; set; }
        public virtual DbSet<Ohjeistus> Ohjeistus { get; set; }
        public virtual DbSet<Oppitunti> Oppitunti { get; set; }
        public virtual DbSet<OppituntiSuoritus> OppituntiSuoritus { get; set; }
        public virtual DbSet<Palaute> Palaute { get; set; }
        public virtual DbSet<SahkopostiLista> SahkopostiLista { get; set; }
        public virtual DbSet<Tehtava> Tehtava { get; set; }
        public virtual DbSet<TehtavaEpaonnistunut> TehtavaEpaonnistunut { get; set; }
        public virtual DbSet<TehtavaSuoritus> TehtavaSuoritus { get; set; }
        public virtual DbSet<Vihje> Vihje { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kayttaja>(entity =>
            {
                entity.Property(e => e.KayttajaId).HasColumnName("kayttaja_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Nimi)
                    .HasColumnName("nimi")
                    .HasMaxLength(100);

                entity.Property(e => e.OnAdmin).HasColumnName("onAdmin");

                entity.Property(e => e.Salasana)
                    .IsRequired()
                    .HasColumnName("salasana")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Kurssi>(entity =>
            {
                entity.Property(e => e.KurssiId).HasColumnName("kurssi_id");

                entity.Property(e => e.KayttajaId).HasColumnName("kayttaja_id");

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(400);

                entity.Property(e => e.Nimi)
                    .HasColumnName("nimi")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Kayttaja)
                    .WithMany(p => p.Kurssi)
                    .HasForeignKey(d => d.KayttajaId)
                    .HasConstraintName("FK__Kurssi__kayttaja__5EBF139D");
            });

            modelBuilder.Entity<KurssiSuoritus>(entity =>
            {
                entity.Property(e => e.KurssiSuoritusId).HasColumnName("kurssiSuoritus_id");

                entity.Property(e => e.KayttajaId).HasColumnName("kayttaja_id");

                entity.Property(e => e.KurssiId).HasColumnName("kurssi_id");

                entity.Property(e => e.SuoritusPvm)
                    .HasColumnName("suoritusPvm")
                    .HasColumnType("date");

                entity.HasOne(d => d.Kayttaja)
                    .WithMany(p => p.KurssiSuoritus)
                    .HasForeignKey(d => d.KayttajaId)
                    .HasConstraintName("FK__KurssiSuo__kaytt__619B8048");

                entity.HasOne(d => d.Kurssi)
                    .WithMany(p => p.KurssiSuoritus)
                    .HasForeignKey(d => d.KurssiId)
                    .HasConstraintName("FK__KurssiSuo__kurss__628FA481");
            });

            modelBuilder.Entity<Ohjeistus>(entity =>
            {
                entity.Property(e => e.OhjeistusId).HasColumnName("Ohjeistus_id");

                entity.Property(e => e.OppituntiId).HasColumnName("Oppitunti_id");

                entity.Property(e => e.TekstiKentta).HasMaxLength(2000);

                entity.HasOne(d => d.Oppitunti)
                    .WithMany(p => p.Ohjeistus)
                    .HasForeignKey(d => d.OppituntiId)
                    .HasConstraintName("FK__Ohjeistus__Oppit__787EE5A0");
            });

            modelBuilder.Entity<Oppitunti>(entity =>
            {
                entity.Property(e => e.OppituntiId).HasColumnName("oppitunti_id");

                entity.Property(e => e.KurssiId).HasColumnName("kurssi_id");

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(400);

                entity.Property(e => e.Nimi)
                    .HasColumnName("nimi")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Kurssi)
                    .WithMany(p => p.Oppitunti)
                    .HasForeignKey(d => d.KurssiId)
                    .HasConstraintName("FK__Oppitunti__kurss__656C112C");
            });

            modelBuilder.Entity<OppituntiSuoritus>(entity =>
            {
                entity.Property(e => e.OppituntiSuoritusId).HasColumnName("oppituntiSuoritus_id");

                entity.Property(e => e.KayttajaId).HasColumnName("kayttaja_id");

                entity.Property(e => e.Kesken).HasColumnName("kesken");

                entity.Property(e => e.OppituntiId).HasColumnName("oppitunti_id");

                entity.Property(e => e.SuoritusPvm)
                    .HasColumnName("suoritusPvm")
                    .HasColumnType("date");

                entity.HasOne(d => d.Kayttaja)
                    .WithMany(p => p.OppituntiSuoritus)
                    .HasForeignKey(d => d.KayttajaId)
                    .HasConstraintName("FK__Oppitunti__kaytt__68487DD7");

                entity.HasOne(d => d.Oppitunti)
                    .WithMany(p => p.OppituntiSuoritus)
                    .HasForeignKey(d => d.OppituntiId)
                    .HasConstraintName("FK__Oppitunti__oppit__693CA210");
            });

            modelBuilder.Entity<Palaute>(entity =>
            {
                entity.Property(e => e.PalauteId).HasColumnName("Palaute_id");

                entity.Property(e => e.Lahettaja).HasMaxLength(50);

                entity.Property(e => e.Pvm)
                    .HasColumnName("PVM")
                    .HasColumnType("date");

                entity.Property(e => e.Teksti).HasMaxLength(2000);
            });

            modelBuilder.Entity<SahkopostiLista>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tehtava>(entity =>
            {
                entity.Property(e => e.TehtavaId).HasColumnName("tehtava_id");

                entity.Property(e => e.Kuvaus)
                    .HasColumnName("kuvaus")
                    .HasMaxLength(400);

                entity.Property(e => e.Nimi)
                    .HasColumnName("nimi")
                    .HasMaxLength(200);

                entity.Property(e => e.OppituntiId).HasColumnName("oppitunti_id");

                entity.Property(e => e.TehtavaUrl)
                    .HasColumnName("tehtavaUrl")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Oppitunti)
                    .WithMany(p => p.Tehtava)
                    .HasForeignKey(d => d.OppituntiId)
                    .HasConstraintName("FK__Tehtava__oppitun__6C190EBB");
            });

            modelBuilder.Entity<TehtavaEpaonnistunut>(entity =>
            {
                entity.HasKey(e => e.EpaonnistunutId)
                    .HasName("PK__TehtavaE__DF833DBA3D9BE282");

                entity.Property(e => e.EpaonnistunutId).HasColumnName("Epaonnistunut_id");

                entity.Property(e => e.TehtavaId).HasColumnName("Tehtava_id");

                entity.Property(e => e.TehtavanNimi).HasMaxLength(50);

                entity.HasOne(d => d.Tehtava)
                    .WithMany(p => p.TehtavaEpaonnistunut)
                    .HasForeignKey(d => d.TehtavaId)
                    .HasConstraintName("FK__TehtavaEp__Tehta__02FC7413");
            });

            modelBuilder.Entity<TehtavaSuoritus>(entity =>
            {
                entity.Property(e => e.TehtavaSuoritusId).HasColumnName("TehtavaSuoritus_id");

                entity.Property(e => e.KayttajaId).HasColumnName("kayttaja_id");

                entity.Property(e => e.SuoritusPvm)
                    .HasColumnName("suoritusPvm")
                    .HasColumnType("date");

                entity.Property(e => e.TehtavaId).HasColumnName("tehtava_id");

                entity.HasOne(d => d.Kayttaja)
                    .WithMany(p => p.TehtavaSuoritus)
                    .HasForeignKey(d => d.KayttajaId)
                    .HasConstraintName("FK__TehtavaSu__kaytt__6EF57B66");

                entity.HasOne(d => d.Tehtava)
                    .WithMany(p => p.TehtavaSuoritus)
                    .HasForeignKey(d => d.TehtavaId)
                    .HasConstraintName("FK__TehtavaSu__tehta__6FE99F9F");
            });

            modelBuilder.Entity<Vihje>(entity =>
            {
                entity.Property(e => e.VihjeId).HasColumnName("Vihje_id");

                entity.Property(e => e.TehtavaId).HasColumnName("Tehtava_id");

                entity.Property(e => e.Vihje1).HasMaxLength(500);

                entity.Property(e => e.Vihje2).HasMaxLength(500);

                entity.Property(e => e.Vihje3).HasMaxLength(500);

                entity.HasOne(d => d.Tehtava)
                    .WithMany(p => p.Vihje)
                    .HasForeignKey(d => d.TehtavaId)
                    .HasConstraintName("FK__Vihje__Tehtava_i__75A278F5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
