using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaOfertas;
using BibliotecaDAL;

namespace BibliotecaBLL
{
    public class OfertaCommand
    {
        Repository<oferta> repo = new Repository<oferta>();

        public oferta Save(oferta oferta)
        {
            repo.Save(oferta);
            return oferta;
        }

        public List<oferta> SaveMultiple(List<oferta> ofertas)
        {
            repo.SaveMultiple(ofertas);
            return ofertas;
        }

        public oferta Update(oferta oferta)
        {
            oferta updateoferta = repo.FindSingleOrDefault(a => a.Id == oferta.Id);

            updateoferta.Aro = oferta.Aro;
            updateoferta.Descripcion = oferta.Descripcion;
            updateoferta.Marca = oferta.Marca;
            updateoferta.Precio = oferta.Precio;

            repo.Update(updateoferta);

            return updateoferta;
        }

        public oferta Get(int Id)
        {
            var oferta = repo.Where(a => a.Id == Id).FirstOrDefault();
            return oferta;
        }



        public List<oferta> GetAll()
        {
            return repo.GetAll().ToList();
        }
    }
}
