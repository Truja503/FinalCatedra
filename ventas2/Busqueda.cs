using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class Busqueda : Form
    {
        public Busqueda(List<Vehiculo> resultados)
        {
            InitializeComponent();
            CargarResultados(resultados); // Llama al método para cargar los resultados al iniciar
        }

        private void CargarResultados(List<Vehiculo> resultados)
        {
            foreach (var producto in resultados)
            {
                Card card = new Card
                {
                    Nombre = producto.NombreVehiculo,
                    Marca = producto.MarcaVehiculo.NombreMarca,
                    Precio = decimal.Parse(producto.Precio.ToString()),
                    Id = producto.IdVehiculo
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
                PanelTargetas2.Controls.Add(card);
            }
        }

        private void PanelTarjetas2_Paint(object sender, PaintEventArgs e)
        {
            // Dejar vacío o agregar algún código de diseño adicional si es necesario
        }
    }
}
