using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using interrapidisimo.Models;
using Duende.IdentityServer.EntityFramework.Entities;

namespace interrapidisimo.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<UserSubject> UserSubjects { get; set; }

    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define la clave primaria para DeviceFlowCodes si no está definida automáticamente
        modelBuilder.Entity<DeviceFlowCodes>().HasKey(dfc => dfc.UserCode);

        modelBuilder.Entity<UserSubject>()
            .HasKey(bc => new { bc.UserId, bc.SubjectId });  
        modelBuilder.Entity<UserSubject>()
            .HasOne(bc => bc.User)
            .WithMany(b => b.UserSubjects)
            .HasForeignKey(bc => bc.UserId);  
        modelBuilder.Entity<UserSubject>()
            .HasOne(bc => bc.subject)
            .WithMany(c => c.UserSubjects)
            .HasForeignKey(bc => bc.SubjectId);
    }
}
