using IngresosWabA.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IngresosWabA.Server.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        :base(options) { }

    public DbSet<Ingresos> Ingresos { get; set; }
}

