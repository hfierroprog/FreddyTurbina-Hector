using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using BibliotecaBicicletas;
using BibliotecaPersonal;

namespace BibliotecaDAL
{
    public class Context : DbContext
    {
        public Context() : base("BDSOLEMNE3")
        {

        }

        DbSet<Usuario> Usuario { get; set; }
        DbSet<bicicleta> Bicicletas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
