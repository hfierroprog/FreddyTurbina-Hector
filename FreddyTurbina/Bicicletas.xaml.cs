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
using BibliotecaBicicletas;
using BibliotecaBLL;

namespace FreddyTurbina
{
    /// <summary>
    /// Lógica de interacción para Bicicletas.xaml
    /// </summary>
    public partial class Bicicletas : Window
    {
        bicicleta bici = new bicicleta();
        List<bicicleta> lista = new List<bicicleta>();
        int contador = 0;
        BicicletaCommand bcmd = new BicicletaCommand();

        public Bicicletas()
        {
            InitializeComponent();
            //Posiciona la ventana en el centro de la pantalla
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            init();
        }

        public void init()
        {
            //TextBox
            txtModelo.Text = string.Empty;
            txtCompra.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtVenta.Text = string.Empty;
            //Combobox
            cboMarca.ItemsSource = Enum.GetValues(typeof(EnumBici.Marca));
            cboOrigen.ItemsSource = Enum.GetValues(typeof(EnumBici.Origen));
            //Actualizar los combobox

            //Marcas
            cboMarca.Items.Refresh();
            cboMarca.SelectedIndex = 0;
            //Origen
            cboOrigen.Items.Refresh();
            cboOrigen.SelectedIndex = 0;
            //DataGrid utilizara la lista como medio de datos
            dtgListado.ItemsSource = bcmd.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contador += 1;
            String errores = string.Empty;//Variable que almacenara los errores

            //Validamos que se ingrese un modelo
            if(txtModelo.Text.Length != 0)
            {
                bici.Modelo = txtModelo.Text.ToString();
            }
            else
            {
                errores += "\n-Debe ingresar un modelo.";
            }

            //Validamos que se ingrese un precio compra
            if(Int32.TryParse(txtCompra.Text, out int prec_compra))
            {
                bici.PrecioCosto = prec_compra;
            }
            else
            {
                errores += "\n-Debe ingresar un precio compra.";
            }

            //Validamos que se ingrese un precio venta
            if (Int32.TryParse(txtVenta.Text, out int prec_venta))
            {
                bici.PrecioVenta = prec_venta;
            }
            else
            {
                errores += "\n-Debe ingresar un precio venta.";
            }

            //Validamos Stock
            if(Int32.TryParse(txtStock.Text,out int stock))
            {
                bici.Stock = stock;
            }
            else
            {
                errores += "\n-Debe ingresar un Stock valido.";
            }

            //Validamos que se seleccione opcion valida combobox
            if(cboMarca.SelectedIndex != 0)
            {
                bici.Marca = cboMarca.Text;
            }
            else
            {
                errores += "\n-Debe seleccionar una marca valida.";
            }

            //Validamos Origen
            if(cboOrigen.SelectedIndex != 0)
            {
                bici.Origen = cboOrigen.Text;
            }
            else
            {
                errores += "\n-Debe seleccionar un origen valido.";
            }

            //Revisamos el estado del checkbox
            if (cbActivo.IsChecked == true)
            {
                bici.Activo = "Si";
            }
            else
            {
                bici.Activo = "No";
            }

            //Asignamos el contador a codigo
            bici.CodigoBicicleta = contador.ToString();
            //Creamos el codigo 
            bici.crearCod();
            //Calculamos la ganancia
            bici.calcularGanancia();

            //Si no hay errores de entrada
            if (errores.Length == 0)
            {
                //Se añade el producto
                try
                {
                    bcmd.Save(bici);
                }
                catch
                {
                    MessageBox.Show("Error al insertar bicicleta!");
                }
                                
                //Se crea el producto
                bici = new bicicleta();
                //Mensaje si es correcto
                MessageBox.Show("Producto Agregado con Exito!");
                //Se refresca el DataGrid
                dtgListado.Items.Refresh();
                init();
            }
            else
            {
                //Muestra los errores a la hora de rellenar el formulario
                MessageBox.Show("Se presentaron los siguientes errores:\n" + errores);
            }
        }
    }
}
