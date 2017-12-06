using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliotecaOfertas;

namespace FreddyTurbina
{
    /// <summary>
    /// Lógica de interacción para Ofertas.xaml
    /// </summary>
    public partial class Ofertas : Window
    {
        //Creamos objeto de tipo oferta
        oferta oferta1;
        oferta oferta2;
        oferta oferta3;
        oferta oferta4;

        public Ofertas()
        {
            InitializeComponent();
            //Posiciona la ventana en el centro de la pantalla
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            init();
        }

        public void init()
        {
            //Se instancia objeto de tipo oferta
            oferta1 = new oferta(55000, "Oxford", 20, "Bicicleta pequeña");
            oferta2 = new oferta(100000, "GT", 26, "Bicicleta grande");
            oferta3 = new oferta(130000, "Giant", 27, "Bicicleta grande");
            oferta4 = new oferta(220000, "Trek", 24, "Bicicleta mediana");
        }

        //Se muestran los objetos de tipo oferta
        private void btnbici1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Datos de bicicleta\n" + "Precio: $" + oferta1.Precio + "\nMarca: " + oferta1.Marca + "\nAro: " + oferta1.Aro + "\nDescripción: " + oferta1.Descripcion);
        }

        private void btnbici2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Datos de bicicleta\n" + "Precio: $" + oferta2.Precio + "\nMarca: " + oferta2.Marca + "\nAro: " + oferta2.Aro + "\nDescripción: " + oferta2.Descripcion);
        }

        private void btnbici3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Datos de bicicleta\n" + "Precio: $" + oferta3.Precio + "\nMarca: " + oferta3.Marca + "\nAro: " + oferta3.Aro + "\nDescripción: " + oferta3.Descripcion);
        }

        private void btnbici4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Datos de bicicleta\n" + "Precio: $" + oferta4.Precio + "\nMarca: " + oferta4.Marca + "\nAro: " + oferta4.Aro + "\nDescripción: " + oferta4.Descripcion);
        }
    }
}