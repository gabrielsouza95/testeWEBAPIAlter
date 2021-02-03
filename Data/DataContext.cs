using Microsoft.EntityFrameworkCore;
using testeAlter.Models;

namespace testeAlter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            //Conection string ficaria aqui
        }

        public DbSet<Produto> Produtos { get;set;}
        public DbSet<Categoria> Categorias {get;set;}
    }
}