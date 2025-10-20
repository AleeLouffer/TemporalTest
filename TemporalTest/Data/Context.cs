using Microsoft.EntityFrameworkCore;
using TemporalTest.Entity;

namespace TemporalTest.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(x =>
            {
                x.HasKey(x => x.Id);
                x.ToTable("Usuario", e => e.IsTemporal(t =>
                {
                    t.HasPeriodStart("Inicio");
                    t.HasPeriodEnd("Fim");
                    t.UseHistoryTable("Usuario_Historico");
                }));
            });
        }
    }
}
