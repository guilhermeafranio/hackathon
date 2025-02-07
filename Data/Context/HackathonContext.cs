using Microsoft.EntityFrameworkCore;
//using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Data.Context;

public class HackathonContext : IdentityDbContext<Usuario>
{
    public HackathonContext(DbContextOptions<HackathonContext> options) : base(options) { }
    public HackathonContext() { } // Construtor sem parâmetros necessário para Migrations


    //public DbSet<Contato> Contato { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configurando as chaves primárias corretamente
        builder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        builder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.UserId, r.RoleId });
        builder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
    }
}