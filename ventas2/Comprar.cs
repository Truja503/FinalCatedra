using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using ventas2.Modelo;
namespace ventas2
{
    public partial class Comprar : Form
    {
        int NombreId;

        public Comprar(int nombre, int marca, double precio, Image imagen)
        {
            InitializeComponent();

            // Asignar los datos a los controles de 'Comprar'
            using (ConsesionariaEntities entities = new ConsesionariaEntities())
            {
                var producto = entities.Vehiculoes.Find(nombre);
                textBox1.Text = producto.NombreVehiculo;
                ImagenCompra.Image = imagen;
                
                NombreId = nombre;
                txtPrecio.Text = precio.ToString();
            }
        }

        private void CalcularTotal()
        {
         
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        { // Validar que los campos no estén vacíos

            if (string.IsNullOrWhiteSpace(txtOnombre.Text) ||
       string.IsNullOrWhiteSpace(txtCantidad.Text) ||
       string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si algún campo está vacío
            }

            // Verificar que la cantidad es un número válido
            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar la orden en la base de datos
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
                try
                {
                    // Verificar que NombreId y MarcaId tengan valores válidos
                    if (NombreId == 0)
                    {
                        MessageBox.Show("Seleccione un cliente y un vehículo válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Crear y agregar la nueva orden a la base de datos
                    Factura orden = new Factura();
                    var vehiculo = db.Vehiculoes.Find(int.Parse(NombreId.ToString()));
                    vehiculo.Cantidad -= int.Parse(txtCantidad.Text);
                    orden.IdCliente = login.idUser;
                    orden.IdVehiculo = int.Parse(NombreId.ToString());
                    orden.Cantidad = int.Parse(txtCantidad.Text);
                    orden.FechaFactura = DateTime.Now;
                    orden.Precio = Double.Parse(txtPrecio.Text);
                    db.Facturas.Add(orden); // Agregar la nueva orden a la base de datos
                    db.SaveChanges(); // Intentar guardar los cambios
                    FormCompletado complete = new FormCompletado();
                    complete.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    // Mostrar el mensaje de excepción detallado
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            CalcularTotal();

        }

        private void Comprar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != null)
            {
                try
                {
                    if (int.Parse(txtCantidad.Text) <= 0)
                    {
                        MessageBox.Show("Ingresa una cantidad entera positiva", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        using (ConsesionariaEntities db = new ConsesionariaEntities()) {
                            var vehiculo = db.Vehiculoes.Find(NombreId);
                            var total = vehiculo.Precio * int.Parse(txtCantidad.Text);
                            txtPrecio.Text = total.ToString();
                         }
                    }
                }
                catch
                {
                    MessageBox.Show("Ingresa una cantidad entera positiva", "Error", MessageBoxButtons.OK);

                }
            }
        }
    }
}
