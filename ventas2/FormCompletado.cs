using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventas2
{
    public partial class FormCompletado : Form
    {
        public FormCompletado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Publico Inicio = new Publico();
            Inicio.Show();
            this.Hide();
        }

        private void FormCompletado_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
