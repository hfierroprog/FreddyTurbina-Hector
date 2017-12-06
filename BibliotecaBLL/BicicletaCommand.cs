using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDAL;
using BibliotecaBicicletas;

namespace BibliotecaBLL
{
    public class BicicletaCommand
    {
        Repository<bicicleta> repo = new Repository<bicicleta>();

        public bicicleta Save(bicicleta bicicleta)
        {
            repo.Save(bicicleta);
            return bicicleta;
        }

        public List<bicicleta> SaveMultiple(List<bicicleta> bicicletas)
        {
            repo.SaveMultiple(bicicletas);
            return bicicletas;
        }

        public bicicleta Update(bicicleta bicicleta)
        {
            bicicleta updatebicicleta = repo.FindSingleOrDefault(a => a.Id == bicicleta.Id);

            updatebicicleta.Activo = bicicleta.Activo;
            updatebicicleta.CodigoBicicleta = bicicleta.CodigoBicicleta;


            repo.Update(updatebicicleta);

            return updatebicicleta;
        }

        public bicicleta Get(int Id)
        {
            var bicicleta = repo.Where(a => a.Id == Id).FirstOrDefault();
            return bicicleta;
        }



        public List<bicicleta> GetAll()
        {
            return repo.GetAll().ToList();
        }
    }
}
