using Microsoft.EntityFrameworkCore;
using Tenant.Domain;

namespace Tenant.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tabelas do banco (DbSet)
    public DbSet<TenantEntity> Tenants { get; set; }
    public DbSet<TenantLogEntity> TenantLogs { get; set; }
    public DbSet<EmpresaEntity> Empresas { get; set; }
    public DbSet<EnderecoEntity> Enderecos { get; set; }
    public DbSet<PlanoEntity> Planos { get; set; }
    public DbSet<PlanoModuloEntity> PlanoModulos { get; set; }
    public DbSet<ModuloEntity> Modulos { get; set; }
    public DbSet<MunicipioEntity> Municipios { get; set; }
    public DbSet<UfEntity> Ufs { get; set; }
    public DbSet<PermissaoEntity> Permissoes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar nomes das tabelas, caso necessário
        modelBuilder.Entity<TenantEntity>().ToTable("tenant");
        modelBuilder.Entity<TenantLogEntity>().ToTable("tenant_log");
        modelBuilder.Entity<EmpresaEntity>().ToTable("empresa");
        modelBuilder.Entity<EnderecoEntity>().ToTable("endereco");
        modelBuilder.Entity<UfEntity>().ToTable("uf");
        modelBuilder.Entity<PlanoEntity>().ToTable("plano");
        modelBuilder.Entity<PlanoModuloEntity>().ToTable("plano_modulo");
        modelBuilder.Entity<ModuloEntity>().ToTable("modulo");  
        modelBuilder.Entity<MunicipioEntity>().ToTable("municipio");
        modelBuilder.Entity<PermissaoEntity>().ToTable("permissao");    
    }
    
    public override int SaveChanges()
    {
        AtualizarCamposCoreEntity();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AtualizarCamposCoreEntity();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AtualizarCamposCoreEntity()
    {
        var now = DateTime.UtcNow;
        
        foreach (var entry in ChangeTracker.Entries<CoreEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.InsertDate = now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdateDate = now;
            }
        }
    }
}