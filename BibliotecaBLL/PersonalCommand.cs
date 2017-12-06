using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDAL;
using BibliotecaPersonal;

namespace BibliotecaBLL
{
    public class PersonalCommand
    {

        Repository<Usuario> repo = new Repository<Usuario>();

        public Usuario Save(Usuario usuario)
        {
            repo.Save(usuario);
            return usuario;
        }

        public List<Usuario> SaveMultiple(List<Usuario> usuarios)
        {
            repo.SaveMultiple(usuarios);
            return usuarios;
        }

        public Usuario Update(Usuario usuario)
        {
            Usuario updateUsuario = repo.FindSingleOrDefault(a => a.Id == usuario.Id);

            updateUsuario.AFP = usuario.AFP;
            updateUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
            updateUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
            updateUsuario.CodigoTrabajador = usuario.CodigoTrabajador;
            updateUsuario.Edad = usuario.Edad;
            updateUsuario.FechaContratacion = usuario.FechaContratacion;
            updateUsuario.Isapre = usuario.Isapre;
            updateUsuario.Nacionalidad = usuario.Nacionalidad;
            updateUsuario.Nombre = usuario.Nombre;
            updateUsuario.Rut = usuario.Rut;
            updateUsuario.SueldoBruto = usuario.SueldoBruto;
            updateUsuario.SueldoLiquido = usuario.SueldoLiquido;

            repo.Update(updateUsuario);

            return updateUsuario;
        }

        public Usuario Get(int Id)
        {
            var usuario = repo.Where(a => a.Id == Id).FirstOrDefault();
            return usuario;
        }



        public List<Usuario> GetAll()
        {
            return repo.GetAll().ToList();
        }
    }
}
