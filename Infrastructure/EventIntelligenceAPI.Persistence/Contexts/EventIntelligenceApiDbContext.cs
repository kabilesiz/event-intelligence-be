using EventIntelligenceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventIntelligenceAPI.Persistence.Contexts;

public class EventIntelligenceApiDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<EventUser> EventUser => Set<EventUser>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Comment> Comments => Set<Comment>();
    public EventIntelligenceApiDbContext(DbContextOptions<EventIntelligenceApiDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventUser>().ToTable("EventUser");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<Message>().ToTable("Messages");
        modelBuilder.Entity<Comment>().ToTable("Comments");
        modelBuilder.Entity<Event>().ToTable("Events");
        
        modelBuilder.Entity<User>()
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany<Comment>(x => x.Comments)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Event>()
            .HasMany<Comment>(x => x.Comments)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Message>()
            .HasOne<User>(x => x.ReceiverUser)
            .WithMany(x => x.ReceivedMessages)
            .HasForeignKey(x => x.ReceiverUserId);
        
        modelBuilder.Entity<Message>()
            .HasOne<User>(x => x.SenderUser)
            .WithMany(x => x.SentMessages)
            .HasForeignKey(x => x.SenderUserId);
        
        modelBuilder.Entity<EventUser>()
            .HasKey(x => new {x.EventId, x.UserId});

        /*modelBuilder.Entity<Comment>()
            .HasMany(c => c.SubComments)
            .WithOne(c => c.ParentComment)
            .HasForeignKey(c => c.ParentId);*/
    }
}