using System;
using System.Drawing;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class Destalles : Form
    {

        int productoId;
        int marcaId;

        public Destalles()
        {
            InitializeComponent();


        }

        public void LoadProductDetails(int productId)
        {
            try
            {
                using (ConsesionariaEntities db = new ConsesionariaEntities())
                {
                    var producto = db.Vehiculoes.Find(productId);
                    productoId = producto.IdVehiculo;
                    marcaId = int.Parse(producto.IdMarca.ToString());

                    if (producto != null)
                    {
                        lblNombre.Text = producto.NombreVehiculo;
                        lblMarca.Text = producto.MarcaVehiculo.NombreMarca.ToString();
                        lblPrecio.Text = "$" + producto.Precio.ToString();
                        lblModelo.Text = producto.Modelo;
                        lblDescripcion.Text = producto.Descripcion.ToString();
                        label4.Text = producto.Año.ToString();
                       
                        // Convertir la imagen de bytes a Image
                        if (producto.Imagen != null)
                        {
                            ImagenDetalle.Image = (Image)new ImageConverter().ConvertFrom(producto.Imagen);
                        }
                        else
                        {
                            ImagenDetalle.Image = null;
                        }

                        label1.Text = producto.Motor.ToString();
                        label2.Text = producto.Transmision.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblMarca_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void lblModelo_Click(object sender, EventArgs e)
        {
        }

        private void lblMotor_Click(object sender, EventArgs e)
        {

        }

        private void lblBateria_Click(object sender, EventArgs e)
        {

        }

        private void lblTrans_Click(object sender, EventArgs e)
        {
        }

        private void Destalles_Load(object sender, EventArgs e)
        {

        }
        private void lblTech_Click(object sender, EventArgs e)
        {

        }

        private void ImagenDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ConsesionariaEntities db = new ConsesionariaEntities())
                {
                    var producto = db.Vehiculoes.Find(productoId);
                    if (producto == null)
                    {
                        MessageBox.Show("El producto no se encontró en la base de datos.", "Error", MessageBoxButtons.OK);
                        return;
                    }

                    if (ImagenDetalle.Image == null)
                    {
                        MessageBox.Show("No hay ninguna imagen asignada.", "Error", MessageBoxButtons.OK);
                        return;
                    }

                    int Idnombre = productoId;
                    int IdMarca = marcaId;
                    double precio = double.Parse(producto.Precio.ToString());
                    Image imagen = ImagenDetalle.Image;

                    // Crear y mostrar el formulario 'Comprar'
                    Comprar formComprar = new Comprar(Idnombre, IdMarca, precio, imagen);
                    formComprar.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
