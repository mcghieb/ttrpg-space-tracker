using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Models.Game;
using ShipEntity = Domain.Models.Game.Ship.Ship;
using Domain.Models.Game.Ship;

namespace Repositories;

public class TtrpgDbContext : DbContext
{
    public TtrpgDbContext(DbContextOptions<TtrpgDbContext> options) : base(options)
    {
    }

    // Entity sets
    public DbSet<User> Users => Set<User>();
    public DbSet<Domain.Models.Game.Game> Games => Set<Domain.Models.Game.Game>();
    public DbSet<Party> Parties => Set<Party>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Npc> Npcs => Set<Npc>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<ShipEntity> Ships => Set<ShipEntity>();
    public DbSet<ShipClassification> ShipClassifications => Set<ShipClassification>();
    public DbSet<Mission> Missions => Set<Mission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure table names
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Domain.Models.Game.Game>().ToTable("Games");
        modelBuilder.Entity<Party>().ToTable("Parties");
        modelBuilder.Entity<Character>().ToTable("Characters");
        modelBuilder.Entity<Npc>().ToTable("Characters"); // TPH - Table Per Hierarchy
        modelBuilder.Entity<Player>().ToTable("Characters"); // TPH - Table Per Hierarchy
        modelBuilder.Entity<ShipEntity>().ToTable("Ships");
        modelBuilder.Entity<ShipClassification>().ToTable("ShipClassifications");
        modelBuilder.Entity<Mission>().ToTable("Missions");

        // Configure Character inheritance (Table Per Hierarchy)
        modelBuilder.Entity<Character>()
            .HasDiscriminator<string>("CharacterType")
            .HasValue<Npc>("NPC")
            .HasValue<Player>("Player");

        // Configure relationships
        
        // Game -> GameMaster (many-to-one)
        modelBuilder.Entity<Domain.Models.Game.Game>()
            .HasOne(g => g.GameMaster)
            .WithMany()
            .HasForeignKey(g => g.GameMasterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Game -> Parties (one-to-many)
        modelBuilder.Entity<Party>()
            .HasOne(p => p.Game)
            .WithMany(g => g.Parties)
            .HasForeignKey(p => p.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        // Game -> WorldMissionLog (one-to-many)
        modelBuilder.Entity<Mission>()
            .HasOne(m => m.Game)
            .WithMany(g => g.WorldMissionLog)
            .HasForeignKey(m => m.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        // Party -> Characters (one-to-many)
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Party)
            .WithMany(p => p.Characters)
            .HasForeignKey(c => c.PartyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Party -> Ships (one-to-many)
        modelBuilder.Entity<ShipEntity>()
            .HasOne(s => s.Party)
            .WithMany(p => p.Ships)
            .HasForeignKey(s => s.PartyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Party -> MissionLog (one-to-many)
        modelBuilder.Entity<Mission>()
            .HasOne(m => m.Party)
            .WithMany(p => p.MissionLog)
            .HasForeignKey(m => m.PartyId)
            .OnDelete(DeleteBehavior.SetNull);

        // Ship -> Classification (many-to-one)
        modelBuilder.Entity<ShipEntity>()
            .HasOne(s => s.Classification)
            .WithMany(sc => sc.Ships)
            .HasForeignKey(s => s.ShipClassificationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Ship -> Crew (one-to-many)
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Ship)
            .WithMany(s => s.Crew)
            .HasForeignKey(c => c.ShipId)
            .OnDelete(DeleteBehavior.SetNull);

        // Player -> User (many-to-one)
        modelBuilder.Entity<Player>()
            .HasOne(p => p.User)
            .WithMany(u => u.Characters)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Party -> Users (many-to-many)
        modelBuilder.Entity<Party>()
            .HasMany(p => p.Users)
            .WithMany(u => u.Parties)
            .UsingEntity(j => j.ToTable("PartyUsers"));

        // Configure owned types for value objects
        modelBuilder.Entity<ShipEntity>()
            .OwnsOne(s => s.MaintenanceInfo);

        modelBuilder.Entity<ShipEntity>()
            .OwnsOne(s => s.CurrentStorageState);

        modelBuilder.Entity<ShipClassification>()
            .OwnsOne(sc => sc.StorageCapacity);

        modelBuilder.Entity<ShipClassification>()
            .OwnsOne(sc => sc.MaintenanceInfo);
    }
}
