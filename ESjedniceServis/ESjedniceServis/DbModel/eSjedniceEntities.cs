namespace ESjedniceServis.DbModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class eSjedniceEntities : DbContext
    {
        public eSjedniceEntities()
            : base("name=eSjedniceModel")
        {
        }

        public virtual DbSet<CHAT_PORUKA> CHAT_PORUKA { get; set; }
        public virtual DbSet<CV_USER_INFO> CV_USER_INFO { get; set; }
        public virtual DbSet<GLAS> GLAS { get; set; }
        public virtual DbSet<PRILOG> PRILOG { get; set; }
        public virtual DbSet<SJEDNICA> SJEDNICA { get; set; }
        public virtual DbSet<STATUS_SJEDNICE> STATUS_SJEDNICE { get; set; }
        public virtual DbSet<STATUS_STAVKE_DNEVNOG_REDA> STATUS_STAVKE_DNEVNOG_REDA { get; set; }
        public virtual DbSet<STATUS_UCESNIKA> STATUS_UCESNIKA { get; set; }
        public virtual DbSet<STAVKA_DNEVNOG_REDA> STAVKA_DNEVNOG_REDA { get; set; }
        public virtual DbSet<TIP_GLASA> TIP_GLASA { get; set; }
        public virtual DbSet<TIP_UCESNIKA> TIP_UCESNIKA { get; set; }
        public virtual DbSet<UCESNIK> UCESNIK { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHAT_PORUKA>()
    .Property(e => e.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);    
            modelBuilder.Entity<CHAT_PORUKA>()
                .Property(e => e.UCESNIK_ID);                

            modelBuilder.Entity<CHAT_PORUKA>()
                .Property(e => e.PORUKA)
                .IsUnicode(false);

            modelBuilder.Entity<CV_USER_INFO>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<CV_USER_INFO>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<CV_USER_INFO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CV_USER_INFO>()
                .HasMany(e => e.UCESNIK)
                .WithRequired(e => e.CV_USER_INFO)
                .HasForeignKey(e => e.UPOSLENIK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GLAS>()
                .Property(e => e.STAVKA_DNEVNOG_REDA_ID);                

            modelBuilder.Entity<GLAS>()
                .Property(e => e.TIP_GLASA_ID);

            modelBuilder.Entity<GLAS>()
                .Property(e => e.UCESNIK_ID);                

            modelBuilder.Entity<PRILOG>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<PRILOG>()
                .Property(e => e.CONTENT_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SJEDNICA>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<SJEDNICA>()
                .Property(e => e.SALA)
                .IsUnicode(false);

            modelBuilder.Entity<SJEDNICA>()
                .Property(e => e.STATUS_SJEDNICE_ID);                

            modelBuilder.Entity<SJEDNICA>()
                .HasMany(e => e.PRILOG)
                .WithRequired(e => e.SJEDNICA)
                .HasForeignKey(e => e.SJEDNICA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SJEDNICA>()
                .HasMany(e => e.STAVKA_DNEVNOG_REDA)
                .WithRequired(e => e.SJEDNICA)
                .HasForeignKey(e => e.SJEDNICA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SJEDNICA>()
                .HasMany(e => e.UCESNIK)
                .WithRequired(e => e.SJEDNICA)
                .HasForeignKey(e => e.SJEDNICA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS_SJEDNICE>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<STATUS_SJEDNICE>()
                .HasMany(e => e.SJEDNICA)
                .WithRequired(e => e.STATUS_SJEDNICE)
                .HasForeignKey(e => e.STATUS_SJEDNICE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS_STAVKE_DNEVNOG_REDA>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<STATUS_STAVKE_DNEVNOG_REDA>()
                .HasMany(e => e.STAVKA_DNEVNOG_REDA)
                .WithRequired(e => e.STATUS_STAVKE_DNEVNOG_REDA)
                .HasForeignKey(e => e.STATUS_STAVKE_DR_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS_UCESNIKA>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<STATUS_UCESNIKA>()
                .HasMany(e => e.UCESNIK)
                .WithRequired(e => e.STATUS_UCESNIKA)
                .HasForeignKey(e => e.STATUS_UCESNIKA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .Property(e => e.SJEDNICA_ID);

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .Property(e => e.REDNI_BROJ);                

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .Property(e => e.NASLOV)
                .IsUnicode(false);

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .Property(e => e.OPIS)
                .IsUnicode(false);

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .Property(e => e.STATUS_STAVKE_DR_ID);                

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .HasMany(e => e.CHAT_PORUKA)
                .WithRequired(e => e.STAVKA_DNEVNOG_REDA)
                .HasForeignKey(e => e.STAVKA_DNEVNOG_REDA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAVKA_DNEVNOG_REDA>()
                .HasMany(e => e.GLAS)
                .WithRequired(e => e.STAVKA_DNEVNOG_REDA)
                .HasForeignKey(e => e.STAVKA_DNEVNOG_REDA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIP_GLASA>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<TIP_GLASA>()
                .HasMany(e => e.GLAS)
                .WithRequired(e => e.TIP_GLASA)
                .HasForeignKey(e => e.TIP_GLASA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIP_UCESNIKA>()
                .Property(e => e.NAZIV)
                .IsUnicode(false);

            modelBuilder.Entity<TIP_UCESNIKA>()
                .HasMany(e => e.UCESNIK)
                .WithRequired(e => e.TIP_UCESNIKA)
                .HasForeignKey(e => e.TIP_UCESNIKA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UCESNIK>()
                .Property(e => e.UPOSLENIK_ID);

            modelBuilder.Entity<UCESNIK>()
                .Property(e => e.SJEDNICA_ID);

            modelBuilder.Entity<UCESNIK>()
                .Property(e => e.TIP_UCESNIKA_ID);

            modelBuilder.Entity<UCESNIK>()
                .Property(e => e.STATUS_UCESNIKA_ID);                

            modelBuilder.Entity<UCESNIK>()
                .HasMany(e => e.CHAT_PORUKA)
                .WithRequired(e => e.UCESNIK)
                .HasForeignKey(e => e.UCESNIK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UCESNIK>()
                .HasMany(e => e.GLAS)
                .WithRequired(e => e.UCESNIK)
                .HasForeignKey(e => e.UCESNIK_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
