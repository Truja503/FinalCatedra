using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
                var user = db.Usuarios.Find(login.idUser);
                if (user != null) { 
                    txtApellido.Text = user.Apellido;
                    txtNombre.Text = user.Nombre;
                    txtPais.Text = user.Pais;
                    txtCorreo.Text = user.Correo;
                    txtPassword.Text = "********";
                    txtTelefono.Text = user.telefono;
                    txtCiudad.Text = user.Ciudad;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtApellido.Text) ||
               string.IsNullOrWhiteSpace(txtCorreo.Text) ||
               string.IsNullOrWhiteSpace(txtTelefono.Text) ||
               string.IsNullOrWhiteSpace(txtPassword.Text) ||
               string.IsNullOrWhiteSpace(txtPais.Text) ||
               string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el correo tenga un formato válido
            if (!IsValidEmail(txtCorreo.Text))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el teléfono contenga solo números
            if (!txtTelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El número de teléfono debe contener solo números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar guardar el usuario en la base de datos
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
                try
                {
                    // Crear la instancia de usuario y asignar los valores
                    Usuario user = new Usuario
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        telefono = txtTelefono.Text,
                        Contraseña = txtPassword.Text,
                        Pais = txtPais.Text,
                        Ciudad = txtCiudad.Text
                    };

                    // Agregar el nuevo usuario a la base de datos
                    db.Usuarios.Add(user);
                    db.SaveChanges();

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Usuario editado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir el formulario de sesión y cerrar el actual
                    Form1 sesion = new Form1();
                    sesion.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Mostrar el mensaje de error en caso de excepción
                    MessageBox.Show("Ocurrió un error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Publico publico = new Publico();
            publico.Show();
            this.Close();
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
