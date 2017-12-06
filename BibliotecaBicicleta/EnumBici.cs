using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaBicicletas
{
    public class EnumBici
    {
        public enum Marca
        {
            seleccione = 0,
            Trek = 1,
            Giant = 2,
            GT = 3,
            Oxford = 4,
            specialized = 5
        }

        public enum Origen
        {
            seleccione = 0,
            Asiatico = 1,
            Eurupeo = 2,
            Americano = 3,
            Africano = 4
        } 
    }
}
