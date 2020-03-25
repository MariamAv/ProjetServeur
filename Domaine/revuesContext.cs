using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetServeur.Domaine
{
    public partial class RevuesContext : DbContext
    {
        public RevuesContext()
        {
        }

        public RevuesContext(DbContextOptions<RevuesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Auteur> Auteur { get; set; }
        public virtual DbSet<Contient> Contient { get; set; }
        public virtual DbSet<Ecrire> Ecrire { get; set; }
        public virtual DbSet<Numero> Numero { get; set; }
        public virtual DbSet<NumeroHasContient> NumeroHasContient { get; set; }
        public virtual DbSet<Revue> Revue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=localhost;port=3310;user=root;password=root;database=revues", x => x.ServerVersion("10.4.8-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("fk_article_article1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contenu)
                    .HasColumnName("contenu")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Titre)
                    .HasColumnName("titre")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany(p => p.InverseArticleNavigation)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("fk_article_article1");
            });

            modelBuilder.Entity<Auteur>(entity =>
            {
                entity.ToTable("auteur");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Contient>(entity =>
            {
                entity.ToTable("contient");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("fk_numero_has_article_article2_idx");

                entity.HasIndex(e => e.NumeroId)
                    .HasName("fk_numero_has_article_numero1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroId)
                    .HasColumnName("numero_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PageDebut)
                    .HasColumnName("page_debut")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PageFin)
                    .HasColumnName("page_fin")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Contient)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_numero_has_article_article2");

                entity.HasOne(d => d.Numero)
                    .WithMany(p => p.Contient)
                    .HasForeignKey(d => d.NumeroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_numero_has_article_numero1");
            });

            modelBuilder.Entity<Ecrire>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.AuteurId })
                    .HasName("PRIMARY");

                entity.ToTable("ecrire");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("fk_article_has_auteur_article_idx");

                entity.HasIndex(e => e.AuteurId)
                    .HasName("fk_article_has_auteur_auteur1_idx");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuteurId)
                    .HasColumnName("auteur_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Ecrire)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_article_has_auteur_article");

                entity.HasOne(d => d.Auteur)
                    .WithMany(p => p.Ecrire)
                    .HasForeignKey(d => d.AuteurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_article_has_auteur_auteur1");
            });

            modelBuilder.Entity<Numero>(entity =>
            {
                entity.ToTable("numero");

                entity.HasIndex(e => e.RevueId)
                    .HasName("fk_numero_revue1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Annee)
                    .HasColumnName("annee")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nbpages)
                    .HasColumnName("nbpages")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RevueId)
                    .HasColumnName("revue_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Revue)
                    .WithMany(p => p.Numero)
                    .HasForeignKey(d => d.RevueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_numero_revue1");
            });

            modelBuilder.Entity<NumeroHasContient>(entity =>
            {
                entity.HasKey(e => new { e.NumeroId, e.ContientArticleId })
                    .HasName("PRIMARY");

                entity.ToTable("numero_has_contient");

                entity.HasIndex(e => e.NumeroId)
                    .HasName("fk_numero_has_contient_numero1_idx");

                entity.Property(e => e.NumeroId)
                    .HasColumnName("numero_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContientArticleId)
                    .HasColumnName("contient_article_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Numero)
                    .WithMany(p => p.NumeroHasContient)
                    .HasForeignKey(d => d.NumeroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_numero_has_contient_numero1");
            });

            modelBuilder.Entity<Revue>(entity =>
            {
                entity.ToTable("revue");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Periodicite)
                    .HasColumnName("periodicite")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
