using Microsoft.EntityFrameworkCore;
using MQTT_WebClient.Model.Entity;

namespace MQTT_WebClient.Database;

public class ApplicationDbContext : DbContext{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionBuilder):base(optionBuilder){}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    //     string path = System.IO.Path.Combine(System.Environment.CurrentDirectory,"Database","MessageStore.db");
    //     optionsBuilder.UseSqlite($"Filename={path}");
    // }

    public DbSet<SubscribedMessage>? SubscribedMessages {get;set;}
    public DbSet<PublishedMessage>? PublishedMessages {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder){

        modelBuilder.Entity<SubscribedMessage>(e => {
            e.HasKey(e => e.Id);
            e.Property(e => e.Message).IsRequired().HasMaxLength(512);
            e.Property(e => e.SubscribTime).IsRequired();
            e.Property(e => e.ServerUrl).IsRequired();
        });
        
        modelBuilder.Entity<PublishedMessage>(e => {
            e.HasKey(e => e.Id);
            e.Property(e => e.Message).IsRequired().HasMaxLength(512);
            e.Property(e => e.PublishTime).IsRequired();
            e.Property(e => e.ServerUrl).IsRequired();
        });
    }


}

