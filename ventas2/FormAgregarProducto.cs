
using System;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ventas2.Modelo;



namespace ventas2
{
    public partial class FormAgregarProducto : Form
    {


        public FormAgregarProducto()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
          
            
        }
        private void LlenarComboBox()
        {
            using (var context = new ConsesionariaEntities())
            {
                var marcas = context.MarcaVehiculoes
                    .Select(m => new { m.IdMarca, m.NombreMarca }) // Seleccionamos solo las columnas necesarias
                    .ToList();

                txtMarca.DataSource = marcas;
                txtMarca.DisplayMember = "NombreMarca";  // Muestra el nombre de la marca
                txtMarca.ValueMember = "IdMarca";        // Almacena el IdMarca como valor
            }
        }




        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDesc.Text) ||
                string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                Imagen.Image == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
         
                Vehiculo Datos = new Vehiculo
                {
                   
                };
                double precioTotal; 
                // Validar y asignar el precio
                if (int.TryParse(txtPrecio.Text, out int precio))
                {
                    precioTotal = precio;
                }
                else
                {
                    MessageBox.Show("El precio ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtMarca.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona una marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir la imagen a un arreglo de bytes
                byte[] imagen = ImagenABytes(Imagen.Image);
                String NombreVehiculo = txtNombre.Text;
                String Descripcion = txtDesc.Text;
                String Modelo = txtModelo.Text;
                // Asignar los demás valores
                double Motor = double.Parse(txtMotor.Text);
                String Transmision = txtTrans.Text;
                int Año = int.Parse(txtTipo.Text);
                int Cantidad = int.Parse(txtBateria.Text);
                int IdMarca= (int)txtMarca.SelectedValue;
                db.AgregarVehiculo(NombreVehiculo, IdMarca, Año, precioTotal, Cantidad, Motor, Modelo, Descripcion, Transmision, imagen);

              
                db.SaveChanges();

                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar campos después de guardar
                    txtNombre.Clear();
                    txtDesc.Clear();
                    txtModelo.Clear();
                    txtPrecio.Clear();
                    Imagen.Image = null;
                    txtMotor.Clear();
                    txtBateria.Clear();
                    txtTipo.Clear();
               

            }
        }

        // Método para convertir una imagen a un arreglo de bytes
        private byte[] ImagenABytes(Image imagen)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // O PNG según el formato que prefieras
                return ms.ToArray();
            }
        }


        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofdSeleccionar.Title = "Seleccionar Imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                Imagen.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'consesionariaDataSet.MarcaVehiculo' Puede moverla o quitarla según sea necesario.
            this.marcaVehiculoTableAdapter.Fill(this.consesionariaDataSet.MarcaVehiculo);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormProductos form1 = new FormProductos();
            form1.Show();
            this.Hide();
        }

        private void Refrescar()
        {
            using (ConsesionariaEntities db = new Modelo.ConsesionariaEntities())
            {
                var lista = from datos in db.Vehiculoes
                            select datos;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAgregarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
