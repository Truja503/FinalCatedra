using System;
using System.Drawing;
using System.Windows.Forms;

namespace ventas2
{
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        public string Nombre
        {
            get => lblNombre.Text;
            set => lblNombre.Text = value;
        }

        public string Marca
        {
            get => lblMarca.Text;
            set => lblMarca.Text = value;
        }

        public decimal Precio
        {
            get => decimal.Parse(lblPrecio.Text);
            set => lblPrecio.Text = value.ToString("C"); // Formato de moneda
        }

        public Image Imagen
        {
            get => ImagenCard.Image;
            set => ImagenCard.Image = value;
        }

        public int Id { get; set; } // Agregar ID para identificar el producto



        private void button1_Click(object sender, EventArgs e)
        {
            Destalles detallesForm = new Destalles();
            detallesForm.LoadProductDetails(Id); // Pasar el ID del producto a la ventana de detalles
            detallesForm.Show();
            this.FindForm()?.Hide();
            
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

        private void Imagen_Click(object sender, EventArgs e)
        {

        }

        private void Card_Load(object sender, EventArgs e)
        {

        }
    }
}
