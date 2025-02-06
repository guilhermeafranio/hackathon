using Microsoft.EntityFrameworkCore;
//using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data.Context;

public class HackathonContext : IdentityDbContext<IdentityUser>
{
    public HackathonContext(DbContextOptions<HackathonContext> options) : base(options) { }

    //public DbSet<Contato> Contato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}