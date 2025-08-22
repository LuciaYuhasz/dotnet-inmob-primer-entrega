using Microsoft.EntityFrameworkCore;

namespace dotnet_inmob_primer_entrega.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }

        // Si querés ver las consultas generadas en consola, podés descomentar esto:
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.LogTo(Console.WriteLine);
        // }
    }
}
