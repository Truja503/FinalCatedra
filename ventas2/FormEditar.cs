using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class FormEditar : Form
    {
        public FormEditar()
        {
            InitializeComponent();
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
                var nombresAutos = db.Vehiculoes.Select(d => d.NombreVehiculo).ToList();
                txtAutos.Items.Clear();
                txtAutos.Items.AddRange(nombresAutos.ToArray());
            }

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un auto en el ComboBox
            if (txtAutos.SelectedItem != null)
            {
                string nombreSeleccionado = txtAutos.SelectedItem.ToString();

                using (ConsesionariaEntities db = new ConsesionariaEntities())
                {
                    // Buscar el auto en la base de datos según el nombre seleccionado
                    var auto = db.Vehiculoes.FirstOrDefault(d => d.NombreVehiculo == nombreSeleccionado);

                    if (auto != null)
                    {
                        // Cargar los datos del auto en los campos correspondientes
                        txtdesc.Text = auto.Descripcion;
                        txtPrecio.Text = auto.Precio.ToString(); // Asegúrate de que txtPrecio sea compatible con el formato
                        txtMarca.Text = auto.MarcaVehiculo.NombreMarca;
                        txtModelo.Text = auto.Modelo;
                        txtTrans.Text = auto.Transmision;
                        txtMotor.Text = auto.Motor.ToString();

                        // Si hay una imagen, asegúrate de que el tipo de dato sea correcto
                        if (auto.Imagen != null && auto.Imagen.Length > 0) // Verifica que la imagen tenga datos
                        {
                            using (var ms = new MemoryStream(auto.Imagen))
                            {
                                Imagen.Image = Image.FromStream(ms); // Cargar la imagen en el PictureBox llamado Imagen
                            }
                        }
                        else
                        {
                            Imagen.Image = null; // Limpiar la imagen si no hay
                        }

                    }
                    else
                    {
                        MessageBox.Show("No se encontró el auto seleccionado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un auto.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un auto en el ComboBox
            if (txtAutos.SelectedItem != null)
            {
                string nombreSeleccionado = txtAutos.SelectedItem.ToString();

                using (ConsesionariaEntities db = new ConsesionariaEntities())
                {
                    // Buscar el auto en la base de datos según el nombre seleccionado
                    var auto = db.Vehiculoes.FirstOrDefault(d => d.NombreVehiculo == nombreSeleccionado);

                    if (auto != null)
                    {
                        // Actualizar los datos del auto
                        auto.Descripcion = txtdesc.Text;

                        // Convertir el precio a int
                        if (int.TryParse(txtPrecio.Text, out int precio))
                        {
                            auto.Precio = precio; // Almacenar el precio como int
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese un precio válido.");
                            return; // Salir del método si el precio no es válido
                        }

                        auto.MarcaVehiculo.NombreMarca = txtMarca.Text;
                        auto.Modelo = txtModelo.Text;
                        auto.Transmision = txtTrans.Text;
                        auto.Año = int.Parse(txtTech.Text);
                        auto.Motor = double.Parse(txtMotor.Text);




                        // Guardar los cambios en la base de datos
                        db.SaveChanges();

                        MessageBox.Show("Los datos del auto han sido actualizados.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el auto seleccionado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un auto.");
            }
        }

    }
}
