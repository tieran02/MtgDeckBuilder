namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MtgContext : DbContext
    {
        public MtgContext()
            : base("data source=DESKTOP-J7G4RC4;initial catalog=mtg;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<MTG_Card> MTG_Card { get; set; }
        public virtual DbSet<MTG_Card_Legalities> MTG_Card_Legalities { get; set; }
        public virtual DbSet<MTG_Card_Subtype> MTG_Card_Subtype { get; set; }
        public virtual DbSet<MTG_Card_Supertype> MTG_Card_Supertype { get; set; }
        public virtual DbSet<MTG_Card_Type> MTG_Card_Type { get; set; }
        public virtual DbSet<MTG_Deck> MTG_Deck { get; set; }
        public virtual DbSet<MTG_Format> MTG_Format { get; set; }
        public virtual DbSet<MTG_Legality> MTG_Legality { get; set; }
        public virtual DbSet<MTG_Rarity> MTG_Rarity { get; set; }
        public virtual DbSet<MTG_Set> MTG_Set { get; set; }
        public virtual DbSet<MTG_SetType> MTG_SetType { get; set; }
        public virtual DbSet<MTG_SubType> MTG_SubType { get; set; }
        public virtual DbSet<MTG_SuperType> MTG_SuperType { get; set; }
        public virtual DbSet<MTG_Type> MTG_Type { get; set; }
        public virtual DbSet<MTG_Deck_Card> MTG_Deck_Card { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.mciNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.flavor)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.manaCost)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.cmc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.power)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.toughness)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.artist)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card>()
                .Property(e => e.cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MTG_Card>()
                .HasMany(e => e.MTG_Card_Type)
                .WithRequired(e => e.MTG_Card)
                .HasForeignKey(e => e.MTG_Card_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Card>()
                .HasMany(e => e.MTG_Card_Supertype)
                .WithRequired(e => e.MTG_Card)
                .HasForeignKey(e => e.MTG_Card_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Card>()
                .HasMany(e => e.MTG_Card_Legalities)
                .WithRequired(e => e.MTG_Card)
                .HasForeignKey(e => e.MTG_Card_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Card>()
                .HasMany(e => e.MTG_Card_Subtype)
                .WithRequired(e => e.MTG_Card)
                .HasForeignKey(e => e.MTG_Card_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Card>()
                .HasMany(e => e.MTG_Deck_Card)
                .WithRequired(e => e.MTG_Card)
                .HasForeignKey(e => e.MTG_Card_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Card_Legalities>()
                .Property(e => e.MTG_Card_id)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card_Subtype>()
                .Property(e => e.MTG_Card_id)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card_Supertype>()
                .Property(e => e.MTG_Card_id)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Card_Type>()
                .Property(e => e.MTG_Card_id)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Deck>()
                .HasMany(e => e.MTG_Deck_Card)
                .WithRequired(e => e.MTG_Deck)
                .HasForeignKey(e => e.MTG_Deck_idMTG_Deck)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Format>()
                .Property(e => e.formatName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Format>()
                .HasMany(e => e.MTG_Card_Legalities)
                .WithRequired(e => e.MTG_Format)
                .HasForeignKey(e => e.MTG_Format_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Legality>()
                .Property(e => e.legalityName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Legality>()
                .HasMany(e => e.MTG_Card_Legalities)
                .WithRequired(e => e.MTG_Legality)
                .HasForeignKey(e => e.MTG_Legality_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Rarity>()
                .Property(e => e.rarityName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Rarity>()
                .HasMany(e => e.MTG_Card)
                .WithRequired(e => e.MTG_Rarity)
                .HasForeignKey(e => e.MTG_Rarity_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Set>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Set>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Set>()
                .Property(e => e.magicCardsInfoCode)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Set>()
                .Property(e => e.mcm_name)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Set>()
                .HasMany(e => e.MTG_Card)
                .WithRequired(e => e.MTG_Set)
                .HasForeignKey(e => e.MTG_Set_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_SetType>()
                .Property(e => e.typeName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_SetType>()
                .HasMany(e => e.MTG_Set)
                .WithRequired(e => e.MTG_SetType)
                .HasForeignKey(e => e.MTG_SetType_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_SubType>()
                .Property(e => e.subtypeName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_SubType>()
                .HasMany(e => e.MTG_Card_Subtype)
                .WithRequired(e => e.MTG_SubType)
                .HasForeignKey(e => e.MTG_SubType_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_SuperType>()
                .Property(e => e.supertypeName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_SuperType>()
                .HasMany(e => e.MTG_Card_Supertype)
                .WithRequired(e => e.MTG_SuperType)
                .HasForeignKey(e => e.MTG_SuperType_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Type>()
                .Property(e => e.typeName)
                .IsUnicode(false);

            modelBuilder.Entity<MTG_Type>()
                .HasMany(e => e.MTG_Card_Type)
                .WithRequired(e => e.MTG_Type)
                .HasForeignKey(e => e.MTG_Type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MTG_Deck_Card>()
                .Property(e => e.MTG_Card_id)
                .IsUnicode(false);
        }
    }
}
