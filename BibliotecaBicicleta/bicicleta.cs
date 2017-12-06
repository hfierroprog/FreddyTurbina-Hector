using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaBicicletas
{
    public class bicicleta
    {
        public int Id{ get; set; }
        public String Modelo{ get; set; }
        public String Marca{ get; set; }
        public int PrecioCosto{ get; set; }
        public int PrecioVenta { get; set; }
        public int Ganancia { get; set; }
        public int Stock{ get; set; }
        public String Origen{ get; set; }
        public String Activo { get; set; }
        public String CodigoBicicleta{ get; set; }



        public void crearCod()
        {
            CodigoBicicleta = "BIC-" + Modelo + "-" + Marca + "-" + Origen + "-" + PrecioVenta + "-" + CodigoBicicleta;
        }

        public void calcularGanancia()
        {
            Ganancia = PrecioVenta - PrecioCosto;
        }
    }
}
