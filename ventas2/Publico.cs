using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class Publico : Form
    {
        public Publico()
        {
            InitializeComponent();
            CargarProductos();
            txtUsuario.Text = login.username;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscarTexto = txtBuscar.Text.Trim(); // Obtener el texto de búsqueda

            if (!string.IsNullOrEmpty(buscarTexto))
            {
                try
                {
                    using (ConsesionariaEntities db = new ConsesionariaEntities())
                    {
                        // Buscar coincidencias en la base de datos (nombre o marca)
                        var resultados = db.Vehiculoes
                            .Where(p => p.NombreVehiculo.Contains(buscarTexto) || p.Modelo.Contains(buscarTexto))
                            .ToList();

                        // Si hay coincidencias, abrir el formulario Busqueda y pasarle los resultados
                        if (resultados.Any())
                        {
                            Busqueda formBusqueda = new Busqueda(resultados);
                            formBusqueda.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron resultados.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la búsqueda: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un texto para buscar.");
            }
        }

        private void CargarProductos()
        {
            try
            {
                using (ConsesionariaEntities db = new ConsesionariaEntities())
                {
                    var productos = db.Vehiculoes.ToList(); // Obtener todos los productos de la tabla 'datos'

                    foreach (var producto in productos)
                    {
                        Card card = new Card
                        {
                            Nombre = producto.NombreVehiculo,
                            Marca = producto.Modelo,
                            Precio = decimal.Parse(producto.Precio.ToString()), // Convierte int? a decimal, asignando 0 si es nulo
                            Id = producto.IdVehiculo // Suponiendo que hay una columna 'id' en la tabla
                        };

                        // Convertir la imagen de bytes a Image si existe
                        if (producto.Imagen != null && producto.Imagen.Length > 0)
                        {
                            using (var ms = new System.IO.MemoryStream(producto.Imagen))
                            {
                                card.Imagen = Image.FromStream(ms);
                            }
                        }

                        // Agregar el control Card al FlowLayoutPanel
                        PanelTargetas.Controls.Add(card);
                    }

                    // Ajustar el tamaño de los controles
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void PanelTargetas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Publico_Load(object sender, EventArgs e)
        {
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
                var carro = db.Vehiculoes.Find(1002);
                if (carro != null)
                {
                    lblNombreVehiculo.Text = carro.NombreVehiculo;
                    lblmarca.Text = carro.MarcaVehiculo.NombreMarca;
                    lblmodelo.Text = carro.Modelo;
                    lblprecio.Text = carro.Precio != null ? carro.Precio.Value.ToString("C") : "N/A";
                }
            }
        }

        private void Publico_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();
            formUsuario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Destalles detallesForm = new Destalles();
            detallesForm.LoadProductDetails(1002); // Pasar el ID del producto a la ventana de detalles
            detallesForm.Show();
            this.FindForm()?.Hide();
        }
    }
}
