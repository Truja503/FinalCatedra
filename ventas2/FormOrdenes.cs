using System;
using System.Linq;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class FormOrdenes : Form
    {
        public FormOrdenes()
        {
            InitializeComponent();
            CargarProductos();
        }
        private void CargarProductos()
        {
           
        }

        private void PanelOrdenes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormOrdenes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'consesionariaDataSet2.VerFacturaCompleta' Puede moverla o quitarla según sea necesario.
            this.verFacturaCompletaTableAdapter.Fill(this.consesionariaDataSet2.VerFacturaCompleta);
            // TODO: esta línea de código carga datos en la tabla 'consesionariaDataSet2.VerFacturaCompleta' Puede moverla o quitarla según sea necesario.
            this.verFacturaCompletaTableAdapter.Fill(this.consesionariaDataSet2.VerFacturaCompleta);
            // TODO: esta línea de código carga datos en la tabla 'consesionariaDataSet1.Facturas' Puede moverla o quitarla según sea necesario.
            this.facturasTableAdapter.Fill(this.consesionariaDataSet1.Facturas);

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormAgregarProducto formAgregar = new FormAgregarProducto();
            formAgregar.Show();
            this.Hide();
        }

        private void FormOrdenes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
