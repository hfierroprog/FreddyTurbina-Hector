using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPersonal
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Rut { get; set; }
        public int Edad { get; set; }
        public String FechaContratacion { get; set; }
        public String Nacionalidad { get; set; }
        public String AFP { get; set; }
        public String Isapre { get; set; }
        public String CodigoTrabajador { get; set; }
        public int SueldoBruto { get; set; }
        public int SueldoLiquido{ get; set; }

        public void CalcularEdad(DateTime nacimiento)
        {
            Edad = DateTime.Now.Year - nacimiento.Year;
        }

        public void CodigoTrab()
        {
            CodigoTrabajador = "TRAB-" + Nacionalidad + "-" + CodigoTrabajador;
        }
    }
}
