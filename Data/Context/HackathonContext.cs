using Microsoft.EntityFrameworkCore;
//using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Models;

namespace Data.Context;

public class HackathonContext : IdentityDbContext<Usuario>
{
    public HackathonContext(DbContextOptions<HackathonContext> options) : base(options) { }

    //public DbSet<Contato> Contato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}