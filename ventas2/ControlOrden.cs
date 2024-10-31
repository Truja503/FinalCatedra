using System;
using System.Linq;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class ControlOrden : UserControl
    {
        public ControlOrden()
        {
            InitializeComponent();
        }

        public string Usuario
        {
            get => txtnombre.Text;
            set => txtnombre.Text = value;
        }
        public string Auto
        {
            get => txtauto.Text;
            set => txtauto.Text = value;
        }
        public int Cantidad
        {
            get => int.Parse(txtcantidad.Text);
            set => txtcantidad.Text = value.ToString();
        }
        public string Color
        {
            get => txtcolor.Text;
            set => txtcolor.Text = value;
        }
        public int Total
        {
            get => int.Parse(txttotal.Text);
            set => txttotal.Text = value.ToString("C");
        }
        public string Estado
        {
            get => txtestado.Text;
            set => txtestado.Text = value;
        }

        public int Id { get; set; }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {

                var orden = db.Facturas.FirstOrDefault(o => o.IdFactura == Id);


                if (orden != null)
                {
                    db.Facturas.Remove(orden);
                    db.SaveChanges();
                    MessageBox.Show("Orden eliminada correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontró una orden con ese Id.");
                }
            }
        }

    }
}
