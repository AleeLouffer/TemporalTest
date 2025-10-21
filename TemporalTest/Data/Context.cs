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
                x.ToTable("Usuario_Teste", e => e.IsTemporal(t =>
                {
                    t.HasPeriodStart("ValidoDe");
                    t.HasPeriodEnd("ValidoAte");
                    t.UseHistoryTable("Usuario_Teste_Historico");
                }));
            });
        }
    }
}
