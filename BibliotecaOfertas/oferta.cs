using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaOfertas
{
    public class oferta
    {
        public int Precio { get; set; }
        public int Aro { get; set; }
        public String Marca { get; set; }
        public String Descripcion { get; set; }

        public oferta(int Precio, String Marca, int Aro, String Descripcion)
        {
            this.Precio = Precio;
            this.Aro = Aro;
            this.Marca = Marca;
            this.Descripcion = Descripcion;
        }
    }
}
